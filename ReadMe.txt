MvcWebUI (ASP.NET Core Web App Model View Controller), Business (Class Library), DataAccess (Class Library) ve AppCore (Class Library) projeleri olu�turulduktan sonra 
solution build edilir ve DataAccess projesine AppCore, Business projesine AppCore ve DataAccess, MvcWebUI projesine ise Business, DataAccess ve AppCore
projeleri referans olarak eklenir:

1) DataAccess katman�nda Entity'ler olu�turulur.
2) AppCore katman�na Microsoft.EntityFrameworkCore.SqlServer ile DataAccess katman�na Microsoft.EntityFrameworkCore.Tools paketleri NuGet'ten indirilir.
.NET versiyonu hangisi ise NuGet'ten o versiyon numaras� ile ba�layan paketler indirilmelidir.
3) DataAccess katman�nda DbContext'ten t�reyen Context ve i�erisindeki DbSet'ler olu�turulur.
4) MvcWebUI katman�ndaki appsettings.json i�erisine connection string 
server=.\\SQLEXPRESS;database=BA_ETradeCore7;user id=sa;password=sa;multipleactiveresultsets=true;trustservercertificate=true; 
formatta yaz�l�r.
5) MvcWebUI katman�nda Program.cs i�erisine builder.Services.AddControllersWithViews(); sat�r�n�n alt�na
IoC Container region'� eklenir.
MvcWebUI katman�na Microsoft.EntityFrameworkCore.Design paketi NuGet'ten indirilerek MvcWebUI projesi Startup Project yap�l�r. 
Tools -> NuGet Package Manager -> Package Manager Console a��l�r, Default project DataAccess se�ilir 
ve �nce add-migration v1 daha sonra update-database komutlar� �al��t�r�l�r.