#nullable disable
using dotnetMidtermStarter.Data;
using dotnetMidtermStarter.Models;
using Google.DataTable.Net.Wrapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dotnetMidtermStarter.Controllers
{

    public class ChartsController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly ILogger<ChartsController> _logger;

        public ChartsController(ApplicationDbContext context, ILogger<ChartsController> logger)
        {
            _context = context;
            _logger = logger;
        }


        // GET: Charts
        public IActionResult Index()
        {
            return View();
        }


        // Get the chart data from the endpoint
        public async Task<IActionResult> OnGet()
        {
            var dt = new Google.DataTable.Net.Wrapper.DataTable();

            try
            {
                // Loading.  
                List<Student> students = await GetStudentsAsync();

                // Setup the chart configuration based on what you need to show on the chart  
                var graphData = students
          .GroupBy(_ => _.Department)
          .Select(g => new
          {
              Name = g.Key,
              Count = g.Count()
          })
          .OrderByDescending(cp => cp.Count)
          .ToList();


                dt.AddColumn(new Column(ColumnType.String, "Name", "Name"));
                dt.AddColumn(new Column(ColumnType.Number, "Count", "Count"));

                foreach (var item in graphData)
                {
                    Row r = dt.NewRow();
                    r.AddCellRange(new Cell[] {
                        new Cell(item.Name),
                        new Cell(item.Count)
                    });

                    dt.AddRow(r);
                }



            }
            catch (Exception ex)
            {
                // ERROR Info  
                Console.Write(ex);
            }

            return Content(dt.GetJson());


        }

        // Get all of the students from DB
        private async Task<List<Student>> GetStudentsAsync()
        {

            var students = await _context.Students.ToListAsync();

            return students!;
        }


    }
}
