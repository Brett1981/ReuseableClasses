using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Re_useable_Classes.ParentalControl
{
    /*How to Use

            Censor censor = new Censor(censoredWords);
            string result;

            result = censor.CensorText("I stubbed my toe. Gosh it hurts!");

     */

    public class Censor
    {
        public static readonly IList<string> censoredWords = new List<string>
                                                             {
                                                                 "wtf",
                                                                 "wop",
                                                                 "whore",
                                                                 "whoar",
                                                                 "wetback",
                                                                 "wank",
                                                                 "vagina",
                                                                 "twaty",
                                                                 "twat",
                                                                 "titty",
                                                                 "titties",
                                                                 "tits",
                                                                 "testicles",
                                                                 "teets",
                                                                 "spunk",
                                                                 "spic",
                                                                 "snatch",
                                                                 "smut",
                                                                 "sluts",
                                                                 "slut",
                                                                 "sleaze",
                                                                 "slag",
                                                                 "shiz",
                                                                 "shitty",
                                                                 "shittings",
                                                                 "shitting",
                                                                 "shitters",
                                                                 "shitter",
                                                                 "shitted",
                                                                 "shits",
                                                                 "shitings",
                                                                 "shiting",
                                                                 "shitfull",
                                                                 "shited",
                                                                 "shit",
                                                                 "shemale",
                                                                 "sheister",
                                                                 "sh!t",
                                                                 "scrotum",
                                                                 "screw",
                                                                 "schlong",
                                                                 "retard",
                                                                 "qweef",
                                                                 "queer",
                                                                 "queef",
                                                                 "pussys",
                                                                 "pussy",
                                                                 "pussies",
                                                                 "pusse",
                                                                 "punk",
                                                                 "prostitute",
                                                                 "pricks",
                                                                 "prick",
                                                                 "pr0n",
                                                                 "pornos",
                                                                 "pornography",
                                                                 "porno",
                                                                 "porn",
                                                                 "pissoff",
                                                                 "pissing",
                                                                 "pissin",
                                                                 "pisses",
                                                                 "pissers",
                                                                 "pisser",
                                                                 "pissed",
                                                                 "piss",
                                                                 "pimp",
                                                                 "phuq",
                                                                 "phuks",
                                                                 "phukking",
                                                                 "phukked",
                                                                 "phuking",
                                                                 "phuked",
                                                                 "phuk",
                                                                 "phuck",
                                                                 "phonesex",
                                                                 "penis",
                                                                 "pecker",
                                                                 "orgasms",
                                                                 "orgasm",
                                                                 "orgasims",
                                                                 "orgasim",
                                                                 "niggers",
                                                                 "nigger",
                                                                 "nigga",
                                                                 "muff",
                                                                 "motherfucks",
                                                                 "motherfuckings",
                                                                 "motherfucking",
                                                                 "motherfuckin",
                                                                 "motherfuckers",
                                                                 "motherfucker",
                                                                 "motherfucked",
                                                                 "motherfuck",
                                                                 "mothafucks",
                                                                 "mothafuckings",
                                                                 "mothafucking",
                                                                 "mothafuckin",
                                                                 "mothafuckers",
                                                                 "mothafucker",
                                                                 "mothafucked",
                                                                 "mothafuckaz",
                                                                 "mothafuckas",
                                                                 "mothafucka",
                                                                 "mothafuck",
                                                                 "merde",
                                                                 "masturbate",
                                                                 "lusting",
                                                                 "lust",
                                                                 "lesbo",
                                                                 "lesbian",
                                                                 "kunilingus",
                                                                 "kums",
                                                                 "kumming",
                                                                 "kummer",
                                                                 "kum",
                                                                 "kuksuger",
                                                                 "kuk",
                                                                 "kraut",
                                                                 "kondums",
                                                                 "kondum",
                                                                 "kock",
                                                                 "knob",
                                                                 "kike",
                                                                 "kawk",
                                                                 "jizz",
                                                                 "jizm",
                                                                 "jiz",
                                                                 "jism",
                                                                 "jesus h christ",
                                                                 "jesus fucking christ",
                                                                 "jerk-off",
                                                                 "jerk",
                                                                 "jap",
                                                                 "jackoff",
                                                                 "jacking off",
                                                                 "jackass",
                                                                 "jack-off",
                                                                 "jack off",
                                                                 "hussy",
                                                                 "hotsex",
                                                                 "horny",
                                                                 "horniest",
                                                                 "hore",
                                                                 "hooker",
                                                                 "honkey",
                                                                 "homo",
                                                                 "hoer",
                                                                 "hell",
                                                                 "hardcoresex",
                                                                 "hard on",
                                                                 "h4x0r",
                                                                 "h0r",
                                                                 "guinne",
                                                                 "gook",
                                                                 "gonads",
                                                                 "goddamn",
                                                                 "gazongers",
                                                                 "gaysex",
                                                                 "gay",
                                                                 "gangbangs",
                                                                 "gangbanged",
                                                                 "gangbang",
                                                                 "fux0r",
                                                                 "furburger",
                                                                 "fuks",
                                                                 "fuk",
                                                                 "fucks",
                                                                 "fuckme",
                                                                 "fuckings",
                                                                 "fucking",
                                                                 "fuckin",
                                                                 "fuckers",
                                                                 "fucker",
                                                                 "fucked",
                                                                 "fuck",
                                                                 "fu",
                                                                 "foreskin",
                                                                 "fistfucks",
                                                                 "fistfuckings",
                                                                 "fistfucking",
                                                                 "fistfuckers",
                                                                 "fistfucker",
                                                                 "fistfucked",
                                                                 "fistfuck",
                                                                 "fingerfucks",
                                                                 "fingerfucking",
                                                                 "fingerfuckers",
                                                                 "fingerfucker",
                                                                 "fingerfucked",
                                                                 "fingerfuck",
                                                                 "fellatio",
                                                                 "felatio",
                                                                 "feg",
                                                                 "feces",
                                                                 "fcuk",
                                                                 "fatSalesOrder",
                                                                 "fatass",
                                                                 "farty",
                                                                 "farts",
                                                                 "fartings",
                                                                 "farting",
                                                                 "farted",
                                                                 "fart",
                                                                 "fags",
                                                                 "fagots",
                                                                 "fagot",
                                                                 "faggs",
                                                                 "faggot",
                                                                 "faggit",
                                                                 "fagging",
                                                                 "fagget",
                                                                 "fag",
                                                                 "ejaculation",
                                                                 "ejaculatings",
                                                                 "ejaculating",
                                                                 "ejaculates",
                                                                 "ejaculated",
                                                                 "ejaculate",
                                                                 "dyke",
                                                                 "dumbass",
                                                                 "douche bag",
                                                                 "dong",
                                                                 "dipshit",
                                                                 "dinks",
                                                                 "dink",
                                                                 "dildos",
                                                                 "dildo",
                                                                 "dike",
                                                                 "dick",
                                                                 "damn",
                                                                 "damn",
                                                                 "cyberfucking",
                                                                 "cyberfuckers",
                                                                 "cyberfucker",
                                                                 "cyberfucked",
                                                                 "cyberfuck",
                                                                 "cyberfuc",
                                                                 "cunts",
                                                                 "cuntlicking",
                                                                 "cuntlicker",
                                                                 "cuntlick",
                                                                 "cunt",
                                                                 "cunnilingus",
                                                                 "cunillingus",
                                                                 "cunilingus",
                                                                 "cumshot",
                                                                 "cums",
                                                                 "cumming",
                                                                 "cummer",
                                                                 "cum",
                                                                 "crap",
                                                                 "cooter",
                                                                 "cocksucks",
                                                                 "cocksucking",
                                                                 "cocksucker",
                                                                 "cocksucked",
                                                                 "cocksuck",
                                                                 "cocks",
                                                                 "cock",
                                                                 "cobia",
                                                                 "clits",
                                                                 "clit",
                                                                 "clam",
                                                                 "circle jerk",
                                                                 "chink",
                                                                 "cawk",
                                                                 "buttpicker",
                                                                 "butthole",
                                                                 "butthead",
                                                                 "buttfucker",
                                                                 "buttfuck",
                                                                 "buttface",
                                                                 "butt hair",
                                                                 "butt fucker",
                                                                 "butt breath",
                                                                 "butt",
                                                                 "butch",
                                                                 "bung hole",
                                                                 "bum",
                                                                 "bullshit",
                                                                 "bull shit",
                                                                 "bucket cunt",
                                                                 "browntown",
                                                                 "browneye",
                                                                 "brown eye",
                                                                 "boner",
                                                                 "bonehead",
                                                                 "blowjobs",
                                                                 "blowjob",
                                                                 "blow job",
                                                                 "bitching",
                                                                 "bitchin",
                                                                 "bitches",
                                                                 "bitchers",
                                                                 "bitcher",
                                                                 "bitch",
                                                                 "bestiality",
                                                                 "bestial",
                                                                 "belly whacker",
                                                                 "beaver",
                                                                 "beastility",
                                                                 "beastiality",
                                                                 "beastial",
                                                                 "bastard",
                                                                 "asswipe",
                                                                 "asskisser",
                                                                 "assholes",
                                                                 "asshole",
                                                                 "asses",
                                                                 "ass lick",
                                                                 "ass"
                                                             };

        public Censor(IEnumerable<string> censoredWords)
        {
            if (censoredWords != null)
            {
                CensoredWords = new List<string>(censoredWords);
            }
        }

        private IList<string> CensoredWords { get; set; }

        public string CensorText(string text)
        {
            if (text == null)
            {
                throw new ArgumentNullException("text");
            }

            return CensoredWords.Select(ToRegexPattern)
                                .Aggregate
                (
                    text,
                    (current,
                     regularExpression) =>
                    Regex.Replace
                        (
                            current,
                            regularExpression,
                            StarCensoredMatch,
                            RegexOptions.IgnoreCase | RegexOptions.CultureInvariant));
        }

        private static string StarCensoredMatch(Match m)
        {
            if (m == null)
            {
                return null;
            }
            string word = m.Captures[0].Value;

            return new string
                (
                '*',
                word.Length);
        }

        private static string ToRegexPattern(string wildcardSearch)
        {
            string regexPattern = Regex.Escape(wildcardSearch);

            regexPattern = regexPattern.Replace
                (
                    @"\*",
                    ".*?");
            regexPattern = regexPattern.Replace
                (
                    @"\?",
                    ".");

            if (regexPattern.StartsWith(".*?"))
            {
                regexPattern = regexPattern.Substring(3);
                regexPattern = @"(^\b)*?" + regexPattern;
            }

            regexPattern = @"\b" + regexPattern + @"\b";

            return regexPattern;
        }
    }
}