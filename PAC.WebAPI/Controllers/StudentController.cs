﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PAC.Domain;
using PAC.IBusinessLogic;

namespace PAC.WebAPI
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentLogic _studentLogic;

        public StudentController(IStudentLogic studentLogic)
        {
            this._studentLogic = studentLogic;
        }

        [HttpGet]
        public IActionResult GetStudents()
        {
            return Ok(_studentLogic.GetStudents().Select(c => new StudentsDTO(c)).ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetStudentById([FromRoute] int id)
        {
            StudentsDTO studentResponseModel = new StudentsDTO(_studentLogic.GetStudentById(id));
            return Ok(studentResponseModel);
        }

        [HttpPost]
        public IActionResult InsertStudent([FromBody] StudentCreateModel student)
        {
            _studentLogic.InsertStudents(student.ToEntity());
            return Ok();
        }
    }
}
