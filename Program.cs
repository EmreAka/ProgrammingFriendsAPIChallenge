var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello Programming Friend ^^ To test the api make a post request to /challenge with {list: []} object where list contains list of integers. ");
app.MapPost("/challenge", (Request request) => {
    BiggestNumber biggestNumber = new BiggestNumber(0,0);
    BiggestNumber biggestSecondNumber = new BiggestNumber(0,0);
    
    foreach (var number in request.Numbers.Distinct()){
      var result = request.Numbers.Count(x => x == number);
      if(biggestNumber.Count < result){
        biggestNumber = new(number, result);
      }
    }

    foreach (var number in request.Numbers.Distinct().Where(x => biggestNumber.Number != x)){
      var result = request.Numbers.Count(x => x == number);
      if(biggestSecondNumber.Count < result){
        biggestSecondNumber = new(number, result);
      }
    }
    
    return Results.Ok($"{biggestNumber.Number}, {biggestSecondNumber.Number}");
});

app.Run();
