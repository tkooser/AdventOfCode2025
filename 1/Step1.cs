var num = 50;
var result = 0;
while(true){
    var instruction = Console.ReadLine();
    if(string.IsNullOrEmpty(instruction)){
        break;
    }
    var numToMove = int.Parse(instruction.Substring(1));
    if(numToMove > 100){
        numToMove = numToMove % 100;
    }
    var dirToMove = instruction.Substring(0,1);
    if(dirToMove == "L"){
        num -= numToMove;
        if(num < 0){
            num += 100;
        }
    }
    else if(dirToMove == "R"){
        num += numToMove;
        if(num >= 100){
            num -= 100;
        }
    }
Console.WriteLine($"{dirToMove} {instruction.Substring(1)} = {num}");
if(num == 0) result++;
}

Console.WriteLine($"Result: {result}");