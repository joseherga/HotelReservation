using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;
using System;
using System.IO;

namespace HotelReservation
{
    public class ReceiptGenerator
    {
        // Method to create a PDF receipt for a reservation
        public static void CreateReceipt(string FullName, string RoomType, int Guests, DateTime checkIn, DateTime checkOut, decimal Rate, string filePath,
            string logoPath = @"C:\Users\Toni\Documents\PCU\Intergrative Programming\Group 8\HotelReservation-master\Logo.png") // Default logo path
        {
            // Calculate nights and total amount
            int totalNights = Math.Max(1, (checkOut - checkIn).Days);
            decimal totalAmount = totalNights * Rate;
            string receiptNumber = $"BL-{DateTime.Now:yyyyMMddHHmmss}"; // Unique receipt number

            // Create PDF document with margins
            var doc = new Document(PageSize.A4, 40, 40, 40, 40);

            using (var fs = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                PdfWriter writer = PdfWriter.GetInstance(doc, fs);
                doc.Open();

                // Define fonts
                BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                Font headerFont = new Font(bf, 16, Font.BOLD);
                Font subHeaderFont = new Font(bf, 11, Font.NORMAL);
                Font labelFont = new Font(bf, 10, Font.BOLD);
                Font valueFont = new Font(bf, 10, Font.NORMAL);
                Font smallFont = new Font(bf, 9, Font.ITALIC);

                // Header table with logo + hotel info
                PdfPTable headerTbl = new PdfPTable(2) { WidthPercentage = 100f };
                headerTbl.SetWidths(new float[] { 1f, 3f });

                PdfPCell logoCell = new PdfPCell() { Border = Rectangle.NO_BORDER, VerticalAlignment = Element.ALIGN_MIDDLE };
                if (!string.IsNullOrWhiteSpace(logoPath) && File.Exists(logoPath))
                {
                    try
                    {
                        var img = Image.GetInstance(logoPath);
                        img.ScaleToFit(72f, 72f);
                        logoCell.AddElement(img);
                    }
                    catch
                    {
                        logoCell.Phrase = new Phrase("", subHeaderFont);
                    }
                }
                headerTbl.AddCell(logoCell);

                PdfPCell infoCell = new PdfPCell()
                {
                    Border = Rectangle.NO_BORDER,
                    VerticalAlignment = Element.ALIGN_MIDDLE,
                    PaddingLeft = 8f
                };
                infoCell.AddElement(new Paragraph("BYTELODGE", headerFont));
                infoCell.AddElement(new Paragraph("", subHeaderFont));
                infoCell.AddElement(new Paragraph($"Receipt #: {receiptNumber}   Issued: {DateTime.Now:MMMM dd, yyyy}", smallFont));
                headerTbl.AddCell(infoCell);

                doc.Add(headerTbl);

                // Divider line
                var line = new LineSeparator(1f, 100f, BaseColor.GRAY, Element.ALIGN_CENTER, -2f);
                doc.Add(new Chunk(line));
                doc.Add(new Paragraph("\n"));

                // Guest and booking details
                PdfPTable detailsTbl = new PdfPTable(2) { WidthPercentage = 100f, SpacingBefore = 4f, SpacingAfter = 8f };
                detailsTbl.SetWidths(new float[] { 1f, 1f });

                PdfPCell left = new PdfPCell() { Border = Rectangle.NO_BORDER };
                left.AddElement(new Phrase("Guest Name:", labelFont));
                left.AddElement(new Phrase(FullName + "\n", valueFont));
                left.AddElement(new Phrase("Room Type:", labelFont));
                left.AddElement(new Phrase(RoomType + "\n", valueFont));
                left.AddElement(new Phrase("Number of Guest/s:", labelFont));
                left.AddElement(new Phrase(Guests.ToString() + "\n", valueFont));

                PdfPCell right = new PdfPCell() { Border = Rectangle.NO_BORDER };
                right.AddElement(new Phrase("Check-In:", labelFont));
                right.AddElement(new Phrase(checkIn.ToString("MMMM dd, yyyy") + "\n", valueFont));
                right.AddElement(new Phrase("Check-Out:", labelFont));
                right.AddElement(new Phrase(checkOut.ToString("MMMM dd, yyyy") + "\n", valueFont));
                right.AddElement(new Phrase("Total Nights:", labelFont));
                right.AddElement(new Phrase(totalNights.ToString() + "\n", valueFont));

                detailsTbl.AddCell(left);
                detailsTbl.AddCell(right);

                doc.Add(detailsTbl);

                // Charges table
                PdfPTable chargesTbl = new PdfPTable(4) { WidthPercentage = 100f, SpacingBefore = 4f, SpacingAfter = 8f };
                chargesTbl.SetWidths(new float[] { 4f, 1f, 1f, 1.5f });

                // Header row
                chargesTbl.AddCell(CreateCell("Description", labelFont, Element.ALIGN_LEFT, hasBorder: false));
                chargesTbl.AddCell(CreateCell("Nights", labelFont, Element.ALIGN_CENTER, hasBorder: false));
                chargesTbl.AddCell(CreateCell("Rate", labelFont, Element.ALIGN_RIGHT, hasBorder: false));
                chargesTbl.AddCell(CreateCell("Line Total", labelFont, Element.ALIGN_RIGHT, hasBorder: false));

                // Room charge row
                chargesTbl.AddCell(CreateCell($"{RoomType} (room rate)", valueFont, Element.ALIGN_LEFT));
                chargesTbl.AddCell(CreateCell(totalNights.ToString(), valueFont, Element.ALIGN_CENTER));
                chargesTbl.AddCell(CreateCell(Rate.ToString("C"), valueFont, Element.ALIGN_RIGHT));
                chargesTbl.AddCell(CreateCell(totalAmount.ToString("C"), valueFont, Element.ALIGN_RIGHT));

                // Downpayment and balance
                decimal downPayment = totalAmount * 0.20m;   // 20% downpayment
                decimal balance = totalAmount - downPayment;

                chargesTbl.AddCell(CreateCell("Downpayment (20%)", labelFont, Element.ALIGN_LEFT, colspan: 3, hasBorder: false));
                chargesTbl.AddCell(CreateCell(downPayment.ToString("C"), valueFont, Element.ALIGN_RIGHT));

                chargesTbl.AddCell(CreateCell("Remaining Balance", labelFont, Element.ALIGN_LEFT, colspan: 3, hasBorder: false));
                chargesTbl.AddCell(CreateCell(balance.ToString("C"), valueFont, Element.ALIGN_RIGHT));

                // Amount paid today row
                PdfPCell paidTodayLabel = new PdfPCell(new Phrase("Amount Paid Today", labelFont))
                {
                    Colspan = 3,
                    HorizontalAlignment = Element.ALIGN_RIGHT,
                    Border = Rectangle.NO_BORDER,
                    PaddingTop = 6f,
                    PaddingBottom = 6f
                };
                chargesTbl.AddCell(paidTodayLabel);

                Font grandTotalFont = new Font(bf, 12, Font.BOLD);
                chargesTbl.AddCell(CreateCell(downPayment.ToString("C"), grandTotalFont, Element.ALIGN_RIGHT));

                doc.Add(chargesTbl);

                // Payment details / thank you note
                PdfPTable bottomTbl = new PdfPTable(2) { WidthPercentage = 100f };
                bottomTbl.SetWidths(new float[] { 2f, 1f });

                PdfPCell noteCell = new PdfPCell() { Border = Rectangle.NO_BORDER };
                noteCell.AddElement(new Paragraph("Payment Method: Card", valueFont));
                noteCell.AddElement(new Paragraph("\nThank you for choosing ByteLodge! Please keep this receipt for your records.", smallFont));
                noteCell.PaddingTop = 6f;
                bottomTbl.AddCell(noteCell);

                // Footer line & contact info
                doc.Add(new Paragraph("\n"));
                var footerLine = new LineSeparator(0.5f, 100f, BaseColor.LIGHT_GRAY, Element.ALIGN_CENTER, -2f);
                doc.Add(new Chunk(footerLine));
                doc.Add(new Paragraph("ByteLodge • 150 Greenwich Street • ByteLodge@mail.com", smallFont) { Alignment = Element.ALIGN_CENTER });

                // Close document
                doc.Close();
                writer.Close();
            }
        }

        // Helper method to create table cells quickly
        private static PdfPCell CreateCell(string text, Font font, int horizAlign = Element.ALIGN_LEFT, int colspan = 1, bool hasBorder = true)
        {
            PdfPCell cell = new PdfPCell(new Phrase(text, font));
            cell.HorizontalAlignment = horizAlign;
            cell.Border = hasBorder ? Rectangle.BOX : Rectangle.NO_BORDER;
            cell.Padding = 6f;
            cell.Colspan = colspan;
            return cell;
        }
    }
}