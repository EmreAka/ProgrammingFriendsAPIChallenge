var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello Programming Friend ^^ To test the api make a post request to /challenge with {list: []} object where list contains list of integers. ");
app.MapPost("/challenge", (Request request) => {
    BiggestNumber biggestNumber = new BiggestNumber(0,0);
    BiggestNumber biggestSecondNumber = new BiggestNumber(0,0);
    var distinctNumbers = request.Numbers.Distinct();
    
    foreach (var number in distinctNumbers){
      var result = request.Numbers.Count(x => x == number);
      if(biggestNumber.Count < result){
        biggestNumber = new(number, result);
      }
    }

    foreach (var number in distinctNumbers.Where(x => biggestNumber.Number != x)){
      var result = request.Numbers.Count(x => x == number);
      if(biggestSecondNumber.Count < result){
        biggestSecondNumber = new(number, result);
      }
    }
    
    return Results.Ok($"{biggestNumber.Number}, {biggestSecondNumber.Number}");
});

app.Run();
