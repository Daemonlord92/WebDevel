using WebDev.DAL.Repo;

WebDevRepository repository = new WebDevRepository();
#region CreateUser
int status;
//status = repository.RegisterUser("Smokeintitan", "123456789", "Testuser@test.com");
//Console.WriteLine(status);
#endregion

#region PostNewProject
//status = repository.PostNewProject("Web Developer Portfolio", "A remaster of my Ruby on Rails Monolithic App.", "https://github.com/Daemonlord92/WebDevel", 100);
//Console.WriteLine(status);
#endregion

#region EditProject
status = repository.EditProject(1002, 101, "Web Development Website", null, null);
Console.WriteLine(status);
#endregion
