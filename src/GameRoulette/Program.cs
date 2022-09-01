var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//Generating knifes
var random = new Random();
var knifes = new List<KnifeDto>();
for (int i = 0; i < 10; i++)
{
    knifes.Add(new(i, $"SomeKnife #{i}", "Factory New", random.Next(1000, 10000)));
}


//Here we creates an endpoint, in our case GET 'localhost:5000/knife'
//That returns a list of knifes that we generated earlier
app.MapGet("/knife", () => 
{
    return knifes;
});

//So the task is to implement new endpoint for buying those knifes
//Basically we pass an id of a knife we want to buy, and method should returns true if it success or false if it's not
//Example of a request POST 'localhost:5000/knife/1/1234'
app.MapPost("/knife/{id}/buy/{price}", (string id, int price) => {
    //Implement logic here
});

//The second task is to implement adding of new knife
//The endpoint should look like POST 'localhost:5000/knife/'

app.UseSwagger();
app.UseSwaggerUI();
app.Run();

public record KnifeDto(int Id, string Name, string Exterior, int Price);