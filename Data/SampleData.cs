#nullable disable

using dotnetMidtermStarter.Models;
using System.Globalization;
using CsvHelper.Configuration;
using CsvHelper;


namespace dotnetMidtermStarter.Data{

    public class SampleData {
  public static void Initialize(IApplicationBuilder app) { 
    using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope()) {
      var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
      context.Database.EnsureCreated();

    // Chechk if there is anything in the db
      if (context.Students.Any()) {
          return;   // DB has already been seeded
      }

    // Add the data if database is empty  
      var students = GetStudents().ToArray();
      context.Students.AddRange(students);
      context.SaveChanges();

    }
  }


//Read the csv file using the function
  public static IEnumerable<Student> GetStudents() {
    var csvFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/students.csv");
    
    var config = new CsvConfiguration(CultureInfo.InvariantCulture) {
        PrepareHeaderForMatch = args => args.Header.ToLower(),
    };

    // Configure the CSVReader based on the data in the CSV file
    
    var data = new List<Student>().AsEnumerable();
    using (var reader = new StreamReader(csvFilePath)) {
        using (var csv = new CsvReader(reader, config)) {
            data = (csv.GetRecords<Student>()).ToList();
        }
    }

    // Set an Id for the new entry
        foreach (Student student in data) { 
           student.Id = System.Guid.NewGuid().ToString();
        }

        return data;
}


}
}