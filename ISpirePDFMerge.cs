using OutSystems.ExternalLibraries.SDK;

namespace OutSystems.SpirePDF
{
    /// <summary>
    /// Provides functionality to merge two PDF documents into a single PDF using the Spire.PDF library.
    /// </summary>
    [OSInterface(Description = "Provides functionality to merge two PDF documents into a single PDF using the Spire.PDF library.", 
        IconResourceName = "SpirePDFMerge.resources.PDF-NET.png")]
    public interface ISpirePDFMerge
    {
        /// <summary>
        /// Merges two PDF files into a single PDF document.
        /// </summary>
        /// <param name="pdfFile1">The first PDF file content as a byte array.</param>
        /// <param name="pdfFile2">The second PDF file content as a byte array.</param>
        /// <param name="mergedPdf">A byte array that will contain the merged PDF document.</param>
        void MergePDFs(
            [OSParameter(Description = "The PDF file contents as byte arrays to be merged.")] byte[] pdfFile1,
            [OSParameter(Description = "The PDF file contents as byte arrays to be merged.")] byte[] pdfFile2,
            [OSParameter(Description = "The output byte array that will contain the converted PDF/A document.")] out byte[] pdfFile);
    }
}