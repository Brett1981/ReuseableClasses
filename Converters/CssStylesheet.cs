using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Xml;

namespace Re_useable_Classes.Converters
{
    internal class CssStylesheet
    {
        // Constructor
        private List<StyleDefinition> _styleDefinitions;

        public CssStylesheet(XmlNode htmlElement)
        {
            if (htmlElement != null)
            {
                DiscoverStyleDefinitions(htmlElement);
            }
        }

        public string GetStyle
            (
            string elementName,
            List<XmlElement> sourceContext)
        {
            Debug.Assert(sourceContext.Count > 0);
            Debug.Assert(elementName == sourceContext[sourceContext.Count - 1].LocalName);

            //  Add id processing for style selectors
            if (_styleDefinitions == null)
            {
                return null;
            }
            for (int i = _styleDefinitions.Count - 1;
                 i >= 0;
                 i--)
            {
                string selector = _styleDefinitions[i].Selector;

                string[] selectorLevels = selector.Split(' ');

                int indexInSelector = selectorLevels.Length - 1;
                string selectorLevel = selectorLevels[indexInSelector].Trim();

                if (MatchSelectorLevel
                    (
                        selectorLevel,
                        sourceContext[sourceContext.Count - 1]))
                {
                    return _styleDefinitions[i].Definition;
                }
            }

            return null;
        }

        private static bool MatchSelectorLevel
            (
            string selectorLevel,
            XmlElement xmlElement)
        {
            if (selectorLevel.Length == 0)
            {
                return false;
            }

            int indexOfDot = selectorLevel.IndexOf('.');
            int indexOfPound = selectorLevel.IndexOf('#');

            string selectorClass = null;
            string selectorId = null;
            string selectorTag = null;
            if (indexOfDot >= 0)
            {
                if (indexOfDot > 0)
                {
                    selectorTag = selectorLevel.Substring
                        (
                            0,
                            indexOfDot);
                }
                selectorClass = selectorLevel.Substring(indexOfDot + 1);
            }
            else if (indexOfPound >= 0)
            {
                if (indexOfPound > 0)
                {
                    selectorTag = selectorLevel.Substring
                        (
                            0,
                            indexOfPound);
                }
                selectorId = selectorLevel.Substring(indexOfPound + 1);
            }
            else
            {
                selectorTag = selectorLevel;
            }

            if (selectorTag != null && selectorTag != xmlElement.LocalName)
            {
                return false;
            }

            if (selectorId != null && HtmlToXamlConverter.GetAttribute
                                          (
                                              xmlElement,
                                              "id") != selectorId)
            {
                return false;
            }

            return selectorClass == null || HtmlToXamlConverter.GetAttribute
                                                (
                                                    xmlElement,
                                                    "class") == selectorClass;
        }

        // Returns a string with all c-style comments replaced by spaces
        private static string RemoveComments(string text)
        {
            int commentStart = text.IndexOf
                (
                    "/*",
                    StringComparison.Ordinal);
            if (commentStart < 0)
            {
                return text;
            }

            int commentEnd = text.IndexOf
                (
                    "*/",
                    commentStart + 2,
                    StringComparison.Ordinal);
            if (commentEnd < 0)
            {
                return text.Substring
                    (
                        0,
                        commentStart);
            }

            return text.Substring
                       (
                           0,
                           commentStart) + " " + RemoveComments(text.Substring(commentEnd + 2));
        }

        private void AddStyleDefinition
            (
            string selector,
            string definition)
        {
            // Notrmalize parameter values
            selector = selector.Trim()
                               .ToLower();
            definition = definition.Trim()
                                   .ToLower();
            if (selector.Length == 0 || definition.Length == 0)
            {
                return;
            }

            if (_styleDefinitions == null)
            {
                _styleDefinitions = new List<StyleDefinition>();
            }

            string[] simpleSelectors = selector.Split(',');

            foreach (
                string simpleSelector in
                    simpleSelectors.Select(t => t.Trim())
                                   .Where(simpleSelector => simpleSelector.Length > 0))
            {
                _styleDefinitions.Add
                    (
                        new StyleDefinition
                            (
                            simpleSelector,
                            definition));
            }
        }

        // Recursively traverses an html tree, discovers STYLE elements and creates a style definition table
        // for further cascading style application
        private void DiscoverStyleDefinitions(XmlNode htmlElement)
        {
            if (htmlElement.LocalName.ToLower() == "link")
            {
                return;
                //  Add LINK elements processing for included stylesheets
                // <LINK href="http://sc.msn.com/global/css/ptnr/orange.css" type=text/css \r\nrel=stylesheet>
            }

            if (htmlElement.LocalName.ToLower() != "style")
            {
                // This is not a STYLE element. Recurse into it
                for (XmlNode htmlChildNode = htmlElement.FirstChild;
                     htmlChildNode != null;
                     htmlChildNode = htmlChildNode.NextSibling)
                {
                    var node = htmlChildNode as XmlElement;
                    if (node != null)
                    {
                        DiscoverStyleDefinitions(node);
                    }
                }
                return;
            }

            // Add style definitions from this style.

            // Collect all text from this style definition
            var stylesheetBuffer = new StringBuilder();

            for (XmlNode htmlChildNode = htmlElement.FirstChild;
                 htmlChildNode != null;
                 htmlChildNode = htmlChildNode.NextSibling)
            {
                if (htmlChildNode is XmlText || htmlChildNode is XmlComment)
                {
                    stylesheetBuffer.Append(RemoveComments(htmlChildNode.Value));
                }
            }

            // CssStylesheet has the following syntactical structure:
            //     @import declaration;
            //     selector { definition }
            // where "selector" is one of: ".classname", "tagname"
            // It can contain comments in the following form: /*...*/

            int nextCharacterIndex = 0;
            while (nextCharacterIndex < stylesheetBuffer.Length)
            {
                // Extract selector
                int selectorStart = nextCharacterIndex;
                while (nextCharacterIndex < stylesheetBuffer.Length && stylesheetBuffer[nextCharacterIndex] != '{')
                {
                    // Skip declaration directive starting from @
                    if (stylesheetBuffer[nextCharacterIndex] == '@')
                    {
                        while (nextCharacterIndex < stylesheetBuffer.Length &&
                               stylesheetBuffer[nextCharacterIndex] != ';')
                        {
                            nextCharacterIndex++;
                        }
                        selectorStart = nextCharacterIndex + 1;
                    }
                    nextCharacterIndex++;
                }

                if (nextCharacterIndex < stylesheetBuffer.Length)
                {
                    // Extract definition
                    int definitionStart = nextCharacterIndex;
                    while (nextCharacterIndex < stylesheetBuffer.Length && stylesheetBuffer[nextCharacterIndex] != '}')
                    {
                        nextCharacterIndex++;
                    }

                    // Define a style
                    if (nextCharacterIndex - definitionStart > 2)
                    {
                        AddStyleDefinition
                            (
                                stylesheetBuffer.ToString
                                    (
                                        selectorStart,
                                        definitionStart - selectorStart),
                                stylesheetBuffer.ToString
                                    (
                                        definitionStart + 1,
                                        nextCharacterIndex - definitionStart - 2));
                    }

                    // Skip closing brace
                    if (nextCharacterIndex < stylesheetBuffer.Length)
                    {
                        Debug.Assert(stylesheetBuffer[nextCharacterIndex] == '}');
                        nextCharacterIndex++;
                    }
                }
            }
        }

        private class StyleDefinition
        {
            public readonly string Definition;
            public readonly string Selector;

            public StyleDefinition
                (
                string selector,
                string definition)
            {
                Selector = selector;
                Definition = definition;
            }
        }
    }
}
