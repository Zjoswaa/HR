/*
    This is a example Program.cs to test your code with.
    Note: This is NOT the same file as the Program.cs used in CodeGrade).
*/

public static class Program_Student {
    public const string PATH_TO_MANIFEST_FOLDER = "manifests/";
    public const string PATH_TO_MANIFEST_FILE = "manifests/manifest001.json";
    public const string SEARCH_ORIGIN = "PER";

    public static void Main() {
        // ContainerManager.Start
        ContainerManager.Start(PATH_TO_MANIFEST_FOLDER);
        ContainerLogger.Print();

        // NEW
        ContainerLogger.GetAverageWeightDeviation(ContainerStatus.ApprovedAfterInspection);
        // NEW
        ContainerLogger.GetDistinctCategories(ContainerStatus.UnderReview);
    }
}
