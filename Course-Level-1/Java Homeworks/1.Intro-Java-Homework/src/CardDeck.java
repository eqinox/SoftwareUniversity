import java.awt.Color;
import java.io.FileOutputStream;

import com.itextpdf.text.BaseColor;
import com.itextpdf.text.Document;
import com.itextpdf.text.Font;
import com.itextpdf.text.Paragraph;
import com.itextpdf.text.pdf.BaseFont;
import com.itextpdf.text.pdf.PdfPTable;
import com.itextpdf.text.pdf.PdfWriter;









public class CardDeck {

	public static void main(String[] args) {
		
			try {
                Document document = new Document();
                PdfWriter.getInstance(document, new FileOutputStream("test.pdf"));                      
                document.open();
               
                PdfPTable table = new PdfPTable(4);
                table.setWidthPercentage(50);
                table.getDefaultCell().setFixedHeight(70);
               
                
               
                String card = "";
                char color = ' ';
               
                for (int i = 2; i <= 14; i++) {
                        switch (i) {
                        case 10: card = "10"; break;
                        case 11: card = " J"; break;
                        case 12: card = " Q"; break;
                        case 13: card = " K"; break;
                        case 14: card = " A"; break;
                        default: card = " " + i; break;
                        }
                        for (int j = 1; j <= 4; j++) {
                                switch (j) {
                                case 1: color = '♣'; table.addCell(new Paragraph(card + color)); break;
                                case 2: color = '♦'; table.addCell(new Paragraph(card + color)); break;
                                case 3: color = '♠'; table.addCell(new Paragraph(card + color)); break;
                                case 4: color = '♥'; table.addCell(new Paragraph(card + color)); break;
                                }
                        }
                }
                document.add(table);
                document.close();                      
        }
        catch (Exception e) {
                e.printStackTrace();
        }
		
	}

}
