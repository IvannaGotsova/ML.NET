﻿
// This file was auto-generated by ML.NET Model Builder. 

using PredictPromotionModel_2;

// Create single instance of sample data from first line of dataset for model input
PredictPromotionModel.ModelInput sampleData = new PredictPromotionModel.ModelInput()
{
    Person_id_ = @"2,",
    Department_ = @"First,",
    First_name_ = @"Francis,",
    Last_name_ = @"Haywood,",
    Age_ = @"39,",
    City_ = @"Judson,",
    State_ = @"SC,",
    Country_ = @"United States,",
    Rating_ = @"7,",
    Experience_ = @"15,",
    Salary = @"4100",
};



Console.WriteLine("Using model to make single prediction -- Comparing actual Promotion_ with predicted Promotion_ from sample data...\n\n");


Console.WriteLine($"Person_id_: {@"2,"}");
Console.WriteLine($"Department_: {@"First,"}");
Console.WriteLine($"First_name_: {@"Francis,"}");
Console.WriteLine($"Last_name_: {@"Haywood,"}");
Console.WriteLine($"Age_: {@"39,"}");
Console.WriteLine($"City_: {@"Judson,"}");
Console.WriteLine($"State_: {@"SC,"}");
Console.WriteLine($"Country_: {@"United States,"}");
Console.WriteLine($"Rating_: {@"7,"}");
Console.WriteLine($"Experience_: {@"15,"}");
Console.WriteLine($"Promotion_: {@"No,"}");
Console.WriteLine($"Salary: {@"4100"}");


var sortedScoresWithLabel = PredictPromotionModel.PredictAllLabels(sampleData);
Console.WriteLine($"{"Class",-40}{"Score",-20}");
Console.WriteLine($"{"-----",-40}{"-----",-20}");

foreach (var score in sortedScoresWithLabel)
{
    Console.WriteLine($"{score.Key,-40}{score.Value,-20}");
}

Console.WriteLine("=============== End of process, hit any key to finish ===============");
Console.ReadKey();

