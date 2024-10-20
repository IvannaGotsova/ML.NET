﻿// This file was auto-generated by ML.NET Model Builder.
using Microsoft.ML;
using Microsoft.ML.Data;
using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
namespace PredictPromotion
{
    public partial class PredictPromotionModel
    {
        /// <summary>
        /// model input class for PredictPromotionModel.
        /// </summary>
        #region model input class
        public class ModelInput
        {
            [LoadColumn(0)]
            [ColumnName(@"person_id,")]
            public float Person_id_ { get; set; }

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
            [ColumnName(@"promotion,")]
            public string Promotion_ { get; set; }

            [LoadColumn(11)]
            [ColumnName(@"salary")]
            public float Salary { get; set; }

        }

        #endregion

        /// <summary>
        /// model output class for PredictPromotionModel.
        /// </summary>
        #region model output class
        public class ModelOutput
        {
            [ColumnName(@"person_id,")]
            public float Person_id_ { get; set; }

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

            [ColumnName(@"promotion,")]
            public uint Promotion_ { get; set; }

            [ColumnName(@"salary")]
            public float Salary { get; set; }

            [ColumnName(@"Features")]
            public float[] Features { get; set; }

            [ColumnName(@"PredictedLabel")]
            public string PredictedLabel { get; set; }

            [ColumnName(@"Score")]
            public float[] Score { get; set; }

        }

        #endregion

        private static string MLNetModelPath = Path.GetFullPath("PredictPromotionModel.mlnet");

        public static readonly Lazy<PredictionEngine<ModelInput, ModelOutput>> PredictEngine = new Lazy<PredictionEngine<ModelInput, ModelOutput>>(() => CreatePredictEngine(), true);


        private static PredictionEngine<ModelInput, ModelOutput> CreatePredictEngine()
        {
            var mlContext = new MLContext();
            ITransformer mlModel = mlContext.Model.Load(MLNetModelPath, out var _);
            return mlContext.Model.CreatePredictionEngine<ModelInput, ModelOutput>(mlModel);
        }

        /// <summary>
        /// Use this method to predict scores for all possible labels.
        /// </summary>
        /// <param name="input">model input.</param>
        /// <returns><seealso cref=" ModelOutput"/></returns>
        public static IOrderedEnumerable<KeyValuePair<string, float>> PredictAllLabels(ModelInput input)
        {
            var predEngine = PredictEngine.Value;
            var result = predEngine.Predict(input);
            return GetSortedScoresWithLabels(result);
        }

        /// <summary>
        /// Map the unlabeled result score array to the predicted label names.
        /// </summary>
        /// <param name="result">Prediction to get the labeled scores from.</param>
        /// <returns>Ordered list of label and score.</returns>
        /// <exception cref="Exception"></exception>
        public static IOrderedEnumerable<KeyValuePair<string, float>> GetSortedScoresWithLabels(ModelOutput result)
        {
            var unlabeledScores = result.Score;
            var labelNames = GetLabels(result);

            Dictionary<string, float> labledScores = new Dictionary<string, float>();
            for (int i = 0; i < labelNames.Count(); i++)
            {
                // Map the names to the predicted result score array
                var labelName = labelNames.ElementAt(i);
                labledScores.Add(labelName.ToString(), unlabeledScores[i]);
            }

            return labledScores.OrderByDescending(c => c.Value);
        }

        /// <summary>
        /// Get the ordered label names.
        /// </summary>
        /// <param name="result">Predicted result to get the labels from.</param>
        /// <returns>List of labels.</returns>
        /// <exception cref="Exception"></exception>
        private static IEnumerable<string> GetLabels(ModelOutput result)
        {
            var schema = PredictEngine.Value.OutputSchema;

            var labelColumn = schema.GetColumnOrNull("promotion,");
            if (labelColumn == null)
            {
                throw new Exception("promotion, column not found. Make sure the name searched for matches the name in the schema.");
            }

            // Key values contains an ordered array of the possible labels. This allows us to map the results to the correct label value.
            var keyNames = new VBuffer<ReadOnlyMemory<char>>();
            labelColumn.Value.GetKeyValues(ref keyNames);
            return keyNames.DenseValues().Select(x => x.ToString());
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
