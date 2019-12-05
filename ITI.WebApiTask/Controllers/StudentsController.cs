using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using ITI.WebApiTask.Models;

namespace ITI.WebApiTask.Controllers
{
    public class StudentsController : ApiController
    {
        private ITIWebApiTaskContext db = new ITIWebApiTaskContext();

        // GET: api/Departments
        public IQueryable<StudentDTO> GetDepartments()
        {
            var departments = from x in db.Departments
                              select new StudentDTO()
                              {
                                 student_id=x.student_id,
                                 emp_name=x.employee.dept_name

                              };
            return departments;

        }

        // GET: api/Departments/5
        [ResponseType(typeof(StudentDetailDTO))]
        public async Task<IHttpActionResult> GetDepartment(int id)
        {
            // Department department = await db.Departments.FindAsync(id);
            var department = await db.Departments.Include(x => x.employee).Select(x => new StudentDetailDTO()
            {

                student_id = x.student_id,
                city=x.city,
                country=x.country,
                emp_name=x.employee.dept_name
            }).SingleOrDefaultAsync(b =>b.student_id==id);
            if (department == null)
            {
                return NotFound();
            }
            else return Ok(department);
           
        }

        // PUT: api/Departments/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutDepartment(int id, student department)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != department.student_id)
            {
                return BadRequest();
            }

            db.Entry(department).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartmentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Departments
        [ResponseType(typeof(student))]
        public async Task<IHttpActionResult> PostDepartment(student department)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Departments.Add(department);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = department.student_id }, department);
        }

        // DELETE: api/Departments/5
        [ResponseType(typeof(student))]
        public async Task<IHttpActionResult> DeleteDepartment(int id)
        {
            student department = await db.Departments.FindAsync(id);
            if (department == null)
            {
                return NotFound();
            }

            db.Departments.Remove(department);
            await db.SaveChangesAsync();

            return Ok(department);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DepartmentExists(int id)
        {
            return db.Departments.Count(e => e.student_id == id) > 0;
        }
    }
}