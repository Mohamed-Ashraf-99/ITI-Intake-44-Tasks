namespace _5_Lab_5
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();



            app.MapAreaControllerRoute(
               name: "area_1",
               areaName: "HR",
               pattern: "HR/{controller=Employee}/{action=ShowAllEmployees}/{id?}"
               );

            app.MapAreaControllerRoute(
              name: "area_2",
              areaName: "Welcom",
              pattern: "Welcom/{controller=Test}/{action=Index}/{id?}"
              );

            //app.MapAreaControllerRoute(
            //  name: "area_3",
            //  areaName: "Finance",
            //  pattern: "Finance/{controller=Hello}/{action=Index}/{id?}"
            //  );

            // For Admin area or other areas if needed
            // app.MapAreaControllerRoute(
            //     name: "area_2",
            //     areaName: "Admin",
            //     pattern: "Admin/{controller=Home}/{action=Index}/{id?}"
            // );

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}"
            );


            app.Run();
        }
    }
}
