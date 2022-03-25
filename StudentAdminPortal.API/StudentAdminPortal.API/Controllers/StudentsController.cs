using Microsoft.AspNetCore.Mvc;
using StudentAdminPortal.API.Repositories;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using StudentAdminPortal.API.DomainModels;
using AutoMapper;

namespace StudentAdminPortal.API.Controllers
{
    [ApiController]
    public class StudentsController : Controller
    {
        private readonly IStudentRepository studentRepository;
        private readonly IMapper mapper;
        public StudentsController(IStudentRepository studentRepository, IMapper mapper)
        {
            this.studentRepository = studentRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("[controller]")]
        public async Task<IActionResult> GetAllStudentsAsync()
        {
            var students = await studentRepository.GetStudentsAsync();
            
            mapper.Map<List<Student>>(students);

            return Ok(mapper.Map<List<Student>>(students));
        }

        [HttpGet]
        [Route("[controller]/{studentId:guid}")]
        public async Task<IActionResult> GetStudentAsync([FromRoute] Guid studentId)
        {
            //Fetch single student details
            var student = await studentRepository
                .GetStudentAsync(studentId);

            // Return student
            if (student == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<Student>(student));
        }
    }
}
