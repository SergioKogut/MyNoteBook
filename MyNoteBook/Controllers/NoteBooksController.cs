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
using MyNoteBook.DataBase;

namespace MyNoteBook.Controllers
{
    public class NoteBooksController : ApiController
    {
        private MyNoteBookDb db = new MyNoteBookDb();

        // GET: api/NoteBooks
        public IQueryable<NoteBook> GetNoteBooks()
        {
            return db.NoteBooks;
        }

        // GET: api/NoteBooks/5
        [ResponseType(typeof(NoteBook))]
        public async Task<IHttpActionResult> GetNoteBook(int id)
        {
            NoteBook noteBook = await db.NoteBooks.FindAsync(id);
            if (noteBook == null)
            {
                return NotFound();
            }

            return Ok(noteBook);
        }

        // PUT: api/NoteBooks/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutNoteBook(int id, NoteBook noteBook)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != noteBook.NoteBookId)
            {
                return BadRequest();
            }

            db.Entry(noteBook).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NoteBookExists(id))
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

        // POST: api/NoteBooks
        [ResponseType(typeof(NoteBook))]
        public async Task<IHttpActionResult> PostNoteBook(NoteBook noteBook)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.NoteBooks.Add(noteBook);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = noteBook.NoteBookId }, noteBook);
        }

        // DELETE: api/NoteBooks/5
        [ResponseType(typeof(NoteBook))]
        public async Task<IHttpActionResult> DeleteNoteBook(int id)
        {
            NoteBook noteBook = await db.NoteBooks.FindAsync(id);
            if (noteBook == null)
            {
                return NotFound();
            }

            db.NoteBooks.Remove(noteBook);
            await db.SaveChangesAsync();

            return Ok(noteBook);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NoteBookExists(int id)
        {
            return db.NoteBooks.Count(e => e.NoteBookId == id) > 0;
        }
    }
}