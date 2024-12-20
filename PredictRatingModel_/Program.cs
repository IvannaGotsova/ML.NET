﻿
// This file was auto-generated by ML.NET Model Builder. 

using PredictRatingModel_;

// Create single instance of sample data from first line of dataset for model input
PredictRatingModel.ModelInput sampleData = new PredictRatingModel.ModelInput()
{
    Person_id = 2F,
    Department = @"First",
    First_name = @"Francis",
    Last_name = @"Haywood",
    Age = 39F,
    City = @"Judson",
    State = @"SC",
    Country = @"United States",
    Experience = 15F,
    Promotion = @"Yes",
    Salary = 4100F,
};



Console.WriteLine("Using model to make single prediction -- Comparing actual Rating with predicted Rating from sample data...\n\n");


Console.WriteLine($"Person_id: {2F}");
Console.WriteLine($"Department: {@"First"}");
Console.WriteLine($"First_name: {@"Francis"}");
Console.WriteLine($"Last_name: {@"Haywood"}");
Console.WriteLine($"Age: {39F}");
Console.WriteLine($"City: {@"Judson"}");
Console.WriteLine($"State: {@"SC"}");
Console.WriteLine($"Country: {@"United States"}");
Console.WriteLine($"Rating: {7F}");
Console.WriteLine($"Experience: {15F}");
Console.WriteLine($"Promotion: {@"Yes"}");
Console.WriteLine($"Salary: {4100F}");


var predictionResult = PredictRatingModel.Predict(sampleData);
Console.WriteLine($"\n\nPredicted Rating: {predictionResult.Score}\n\n");

Console.WriteLine("=============== End of process, hit any key to finish ===============");
Console.ReadKey();

