﻿// This file was auto-generated by ML.NET Model Builder.
using Microsoft.ML;
using Microsoft.ML.Data;
using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
namespace PredictNumber_ValuePrediction
{
    public partial class PredictNumberModel
    {
        /// <summary>
        /// model input class for PredictNumberModel.
        /// </summary>
        #region model input class
        public class ModelInput
        {
            [LoadColumn(0)]
            [ColumnName(@"person_id,")]
            public string Person_id_ { get; set; }

            [LoadColumn(1)]
            [ColumnName(@"department,")]
            public string Department_ { get; set; }

            [LoadColumn(2)]
            [ColumnName(@"first_name,")]
            public string First_name_ { get; set; }

            [LoadColumn(3)]
            [ColumnName(@"last_name,")]
            public string Last_name_ { get; set; }

            [LoadColumn(4)]
            [ColumnName(@"age,")]
            public float Age_ { get; set; }

            [LoadColumn(5)]
            [ColumnName(@"city,")]
            public string City_ { get; set; }

            [LoadColumn(6)]
            [ColumnName(@"state,")]
            public string State_ { get; set; }

            [LoadColumn(7)]
            [ColumnName(@"country,")]
            public string Country_ { get; set; }

            [LoadColumn(8)]
            [ColumnName(@"rating,")]
            public float Rating_ { get; set; }

            [LoadColumn(9)]
            [ColumnName(@"experience,")]
            public float Experience_ { get; set; }

            [LoadColumn(10)]
            [ColumnName(@"salary")]
            public float Salary { get; set; }

        }

        #endregion

        /// <summary>
        /// model output class for PredictNumberModel.
        /// </summary>
        #region model output class
        public class ModelOutput
        {
            [ColumnName(@"person_id,")]
            public float[] Person_id_ { get; set; }

            [ColumnName(@"department,")]
            public float[] Department_ { get; set; }

            [ColumnName(@"first_name,")]
            public float[] First_name_ { get; set; }

            [ColumnName(@"last_name,")]
            public float[] Last_name_ { get; set; }

            [ColumnName(@"age,")]
            public float Age_ { get; set; }

            [ColumnName(@"city,")]
            public float[] City_ { get; set; }

            [ColumnName(@"state,")]
            public float[] State_ { get; set; }

            [ColumnName(@"country,")]
            public float[] Country_ { get; set; }

            [ColumnName(@"rating,")]
            public float Rating_ { get; set; }

            [ColumnName(@"experience,")]
            public float Experience_ { get; set; }

            [ColumnName(@"salary")]
            public float Salary { get; set; }

            [ColumnName(@"Features")]
            public float[] Features { get; set; }

            [ColumnName(@"Score")]
            public float Score { get; set; }

        }

        #endregion

        private static string MLNetModelPath = Path.GetFullPath("PredictNumberModel.mlnet");

        public static readonly Lazy<PredictionEngine<ModelInput, ModelOutput>> PredictEngine = new Lazy<PredictionEngine<ModelInput, ModelOutput>>(() => CreatePredictEngine(), true);


        private static PredictionEngine<ModelInput, ModelOutput> CreatePredictEngine()
        {
            var mlContext = new MLContext();
            ITransformer mlModel = mlContext.Model.Load(MLNetModelPath, out var _);
            return mlContext.Model.CreatePredictionEngine<ModelInput, ModelOutput>(mlModel);
        }

        /// <summary>
        /// Use this method to predict on <see cref="ModelInput"/>.
        /// </summary>
        /// <param name="input">model input.</param>
        /// <returns><seealso cref=" ModelOutput"/></returns>
        public static ModelOutput Predict(ModelInput input)
        {
            var predEngine = PredictEngine.Value;
            return predEngine.Predict(input);
        }

    }
}