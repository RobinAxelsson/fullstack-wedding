public class HtmlParser
{
    private readonly IConfiguration configuration;
    private readonly ILogger<HtmlParser> logger;

    public HtmlParser(IConfiguration configuration, ILogger<HtmlParser> logger)
    {
        this.configuration = configuration;
        this.logger = logger;
    }
    public string ParseTemplate(Guest guest)
    {
        var html = File.ReadAllText(configuration["Email:Template"]);
        html = html.Replace("@FrontendSrc", configuration["Email:FrontendSrc"]);
        html = html.Replace("@ImageSrc", configuration["Email:ImageSrc"]);
        html = html.Replace("@PTag", PTag(guest.MyPreferedLanguage, guest.Name.Split()[0]));
        html = html.Replace("@ButtonText", ButtonText(guest.MyPreferedLanguage));
        return html;
    }
    public string ButtonText(string language) => language switch
    {
        "swe"    => "Tillbaka till bröllopssidan",
        "kurdi" => $"Warawa, warawa",
        "eng"  => $"Back to wedding web site",
        _ => throw new ArgumentOutOfRangeException(nameof(language), $"Not expected direction value: {language}"),
    };

    public string PTag(string language, string name) => language switch
    {
        "swe"    => $"<p>Hej {name},<br>Du finns nu på vår gästlista!<br>Ses den 9:e juli! 💕</p>",
        "kurdi" => $"<p>Slaw {name},<br>Spas!<br>9:e juli! 💕</p>",
        "eng"  => $"<p>Hello {name},<br>You are now on our guest list!<br>See you 9th of July! 💕</p>",
        _ => throw new ArgumentOutOfRangeException(nameof(language), $"Not expected direction value: {language}"),
    };
}