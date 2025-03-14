using System.IO;
using OutSystems.ExternalLibraries.SDK;
using Spire.Pdf;
using System;

namespace OutSystems.SpirePDF
{
    /// <summary>
    /// Provides functionality to merge two PDF documents into a single PDF using the Spire.PDF library.
    /// </summary>
    public class SpirePDFUtilities : ISpirePDFMerge
    {
        /// <summary>
        /// Merges two PDF files into a single PDF document.
        /// </summary>
        /// <param name="pdfFile1">The first PDF file content as a byte array.</param>
        /// <param name="pdfFile2">The second PDF file content as a byte array.</param>
        /// <param name="mergedPdf">A byte array that will contain the merged PDF document.</param>
        public void MergePDFs(
            [OSParameter(Description = "The content of the first PDF file as a byte array.")] byte[] pdfFile1,
            [OSParameter(Description = "The content of the second PDF file as a byte array.")] byte[] pdfFile2,
            [OSParameter(Description = "The output byte array that will contain the merged PDF document.")] out byte[] mergedPdf)
        {
            // Validate input parameters
            if (pdfFile1 == null || pdfFile1.Length == 0)
            {
                throw new ArgumentException("The first PDF file is empty or null.", nameof(pdfFile1));
            }

            if (pdfFile2 == null || pdfFile2.Length == 0)
            {
                throw new ArgumentException("The second PDF file is empty or null.", nameof(pdfFile2));
            }

            // Create a PdfDocument to store the merged result
            PdfDocument mergedDocument = new PdfDocument();

            // Merge the first PDF file
            using (MemoryStream memoryStream1 = new MemoryStream(pdfFile1))
            {
                PdfDocument document1 = new PdfDocument();
                document1.LoadFromStream(memoryStream1);
                mergedDocument.AppendPage(document1); // Append first document
            }

            // Merge the second PDF file
            using (MemoryStream memoryStream2 = new MemoryStream(pdfFile2))
            {
                PdfDocument document2 = new PdfDocument();
                document2.LoadFromStream(memoryStream2);
                mergedDocument.AppendPage(document2); // Append second document
            }

            // Save the merged PDF to output byte array
            using (MemoryStream outputStream = new MemoryStream())
            {
                mergedDocument.SaveToStream(outputStream);
                mergedPdf = outputStream.ToArray(); // Return the merged PDF as byte array
            }
        }
    }
}