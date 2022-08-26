using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskInteview.Data;
using TaskInteview.Dtos;
using TaskInteview.Extentions;
using TaskInteview.Helpers;
using TaskInteview.Model;

namespace TaskInteview.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentInEmployeeController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public DepartmentInEmployeeController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]

        public IActionResult GetAll()
        {
            var query = _context.Employees;

            EmployeeListDto employeeListDto = new EmployeeListDto();
            employeeListDto.Items = query
                .Select(p => new EmployeeReturnDto
                {
                    Name = p.Name,
                    Surname = p.Surname,
                    BirthDate = p.BirthDate,
                    Department = new EmployeeDepartmentDto
                    {
                        Name = p.Department.Name
                    }
                })
                .ToList();
            employeeListDto.TotalCount = query.Count();

            return StatusCode(200, employeeListDto);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetOne(int id)
        {
            Employee query = _context.Employees.Include(d => d.Department).FirstOrDefault(p => p.Id == id);
            if (query == null)
            {
                return BadRequest();
            }
            EmployeeReturnDto employeeReturnDto = _mapper.Map<EmployeeReturnDto>(query);



            return StatusCode(200, employeeReturnDto);
        }

        [HttpPost]
        public IActionResult Create(EmployeeCreateDto employeeCreateDto)
        {
            Employee newEmployee = new Employee
            {
                Name = employeeCreateDto.Name,
                Surname = employeeCreateDto.Surname,
                BirthDate = employeeCreateDto.BirthDate,
                CreateDate = DateTime.Now,
                DepartmentId = employeeCreateDto.DepartmentId

            };
            _context.Employees.Add(newEmployee);
            _context.SaveChanges();
            return StatusCode(201, "Employee yaradıldı");
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, EmployeeUpdateDto employeeUpdateDto)
        {
            Employee employee = _context.Employees.FirstOrDefault(p => p.Id == id);
            if (employee == null)
            {
                return NotFound();
            }
            employee.Name = employeeUpdateDto.Name;
            employee.Surname = employeeUpdateDto.Surname;
            employee.BirthDate = employeeUpdateDto.BirthDate;
            employee.DepartmentId = employeeUpdateDto.DepartmentId;

            _context.SaveChanges();
            return StatusCode(200, employee.Id);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Employee employee = _context.Employees.FirstOrDefault(p => p.Id == id);
            if (employee == null)
            {
                return NotFound();
            }
            _context.Employees.Remove(employee);
            _context.SaveChanges();
            return Ok();
        }

        [HttpGet("filter")]
        public async Task<ActionResult<ICollection<Employee>>> GetFilteredEmployees([FromQuery] PageFilter pageFilter, string? name = null, string? surname = null, int? depid = 0)
        {

            var employees = _context.Employees.AsQueryable();

            if (name != null)
            {
                employees = employees.Where(e => e.Name.ToLower().Contains(name.ToLower()));
            }
            if (surname != null)
            {
                employees = employees.Where(e => e.Surname.ToLower().Contains(surname.ToLower()));
            }
            if (depid != 0)
            {
                employees = employees.Where(e => e.DepartmentId == depid);
            }

            var pagedList = await PageList<Employee>.CreateAsync(employees, pageFilter.PageNumber, pageFilter.PageSize);
            Response.AddPaginationHeader(pagedList.CurrentPage, pagedList.PageSize, pagedList.TotalCount, pagedList.TotalPages);

            return pagedList.ToList();
        }


        [HttpGet("search")]
        public async Task<IActionResult> Filter(string search)
        {
            if (search == null)
            {
                return BadRequest();
            }
            var employee = await _context.Employees.Include(d => d.Department)
                .Where(n => n.Name.ToLower().Contains(search.ToLower())
                || n.Surname.ToLower().Contains(search.ToLower())
                || n.Department.Name.ToLower().Contains(search.ToLower()))
                .Take(10).ToListAsync();

            return Ok(employee);
        }

    }
}
