using Microsoft.AspNetCore.Mvc;

namespace tpmodul10_1302220002.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MahasiswaController : ControllerBase
    {
        private static List<string> CourseList = new List<string>
        {
            "KPL", "PBO", "Basdat"
        };
        private static List<Mahasiswa> mahasiswaList = new List<Mahasiswa> {
            new Mahasiswa("Fionadhilla Gustriani", "1302220002", CourseList, 2024),
            new Mahasiswa("Rafli Ahmad Denistri", "1302223153", CourseList, 1998),
            new Mahasiswa("Reinhard Efraim", "1302220001", CourseList, 2021),
            new Mahasiswa("Rizky Kusuma", "1302220000", CourseList, 2029),
            new Mahasiswa("Gabrielle Adsense", "1302229999", CourseList, 2027)
        };


        [HttpGet]
        public IEnumerable<Mahasiswa> Get()
        {
            return mahasiswaList;
        }


        [HttpGet("{id}")]
        public Mahasiswa Get(int id)
        {
            return mahasiswaList[id];
        }

        [HttpPost]
        public ActionResult Post([FromBody] Mahasiswa mahasiswa)
        {
            mahasiswaList.Add(mahasiswa);
            return CreatedAtAction(nameof(Get), new { id = mahasiswaList.IndexOf(mahasiswa) }, mahasiswa);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            mahasiswaList.RemoveAt(id);
            return NoContent();
        }
    }
}