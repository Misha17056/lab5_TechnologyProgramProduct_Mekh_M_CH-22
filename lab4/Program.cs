using System;

namespace lab4
{
    public abstract class Report
    {
        public abstract void Generate();
    }

    public class PDFReport : Report
    {
        public override void Generate()
        {
            Console.WriteLine("Generating PDF Report");
        }
    }

    public class HTMLReport : Report
    {
        public override void Generate()
        {
            Console.WriteLine("Generating HTML Report");
        }
    }

    public class CSVReport : Report
    {
        public override void Generate()
        {
            Console.WriteLine("Generating CSV Report");
        }
    }

    public abstract class ReportFactory
    {
        public abstract Report CreateReport();

        public Report GenerateReport()
        {
            Report report = CreateReport();
            report.Generate();
            return report;
        }
    }

    public class PDFReportFactory : ReportFactory
    {
        public override Report CreateReport()
        {
            return new PDFReport();
        }
    }

    public class HTMLReportFactory : ReportFactory
    {
        public override Report CreateReport()
        {
            return new HTMLReport();
        }
    }

    public class CSVReportFactory : ReportFactory
    {
        public override Report CreateReport()
        {
            return new CSVReport();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            ReportFactory pdfFactory = new PDFReportFactory();
            ReportFactory htmlFactory = new HTMLReportFactory();
            ReportFactory csvFactory = new CSVReportFactory();

            Console.WriteLine("Generating different types of reports:");
            
            pdfFactory.GenerateReport();
            htmlFactory.GenerateReport();
            csvFactory.GenerateReport();

            Console.ReadLine();
        }
    }
}
