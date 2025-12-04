var num = 50;
var result = 0;
while(true){
    var instruction = Console.ReadLine();
    string debugInfo = "";
    if(string.IsNullOrEmpty(instruction)){
        break;
    }
    var numToMove = int.Parse(instruction.Substring(1));
    var addResult = true;
    if(numToMove > 100){
        result += (numToMove / 100);
        //addResult = false;
        debugInfo += $"Added {numToMove / 100} to result for full rotations. ";
        numToMove = numToMove % 100;
    }
    var dirToMove = instruction.Substring(0,1);
    if(dirToMove == "L"){
        if(num == 0) addResult = false;
        num -= numToMove;
        //Console.WriteLine($"Num after move: {num}");
        if(num < 0){
            num += 100;
            if(addResult){ 
                result++;
                debugInfo += $"Added 1 to result for crossing 0 going left with num of {num - 100}. ";
            }
        }
    }
    else if(dirToMove == "R"){
        num += numToMove;
        if(num >= 100){
            num -= 100;
            if(addResult && num != 0){
                 result++;
                 debugInfo += $"Added 1 to result for crossing 0 going right with num of {num + 100}. ";
            }
        }
    }
    if(num == 0){
         result++;
         debugInfo += $"Added 1 to result for landing on 0. ";
    }

    Console.WriteLine($"{dirToMove} {instruction.Substring(1)} = {num}; Result = {result}. {debugInfo}");
}

Console.WriteLine($"Result: {result}");