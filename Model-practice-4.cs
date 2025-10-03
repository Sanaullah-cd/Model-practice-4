using System;

// 1. Document interface
public interface IDocument
{
    void Open();
}

// 2. Concrete Documents
public class Report : IDocument
{
    public void Open()
    {
        Console.WriteLine("Opening Report document...");
    }
}

public class Resume : IDocument
{
    public void Open()
    {
        Console.WriteLine("Opening Resume document...");
    }
}

public class Letter : IDocument
{
    public void Open()
    {
        Console.WriteLine("Opening Letter document...");
    }
}

// Extra: Invoice
public class Invoice : IDocument
{
    public void Open()
    {
        Console.WriteLine("Opening Invoice document...");
    }
}

// 3. Abstract Factory
public abstract class DocumentCreator
{
    public abstract IDocument CreateDocument();
}

// 4. Concrete Factories
public class ReportCreator : DocumentCreator
{
    public override IDocument CreateDocument()
    {
        return new Report();
    }
}

public class ResumeCreator : DocumentCreator
{
    public override IDocument CreateDocument()
    {
        return new Resume();
    }
}

public class LetterCreator : DocumentCreator
{
    public override IDocument CreateDocument()
    {
        return new Letter();
    }
}

public class InvoiceCreator : DocumentCreator
{
    public override IDocument CreateDocument()
    {
        return new Invoice();
    }
}

// 5. Main Program
public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Choose document type: Report / Resume / Letter / Invoice");
        string choice = Console.ReadLine();

        DocumentCreator creator = choice.ToLower() switch
        {
            "report" => new ReportCreator(),
            "resume" => new ResumeCreator(),
            "letter" => new LetterCreator(),
            "invoice" => new InvoiceCreator(),
            _ => throw new Exception("Unknown document type")
        };

        IDocument document = creator.CreateDocument();
        document.Open();
    }
}
