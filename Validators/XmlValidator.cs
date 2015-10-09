using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml.Schema;

namespace Re_useable_Classes.Validators
{
    public class XmlValidator
    {
        string _schemaFileName = "";
        List<Exception> _errors = null;

        public XmlValidator(string schemaFileName)
        {
            _schemaFileName = schemaFileName;
            validateInputs();
        }

        void validateInputs()
        {
            if (!File.Exists(_schemaFileName))
                throw new InvalidOperationException(string.Format("XML schema '{0}' does not exist", _schemaFileName));
        }

        public List<Exception> ValidateXml(XDocument doc)
        {
            _errors = new List<Exception>();

            var schemaSet = new XmlSchemaSet();
            schemaSet.Add(null, _schemaFileName);

            doc.Validate(schemaSet, new ValidationEventHandler(validationEvent));

            return _errors;
        }

        void validationEvent(object sender, ValidationEventArgs eventArgs)
        {
            _errors.Add(eventArgs.Exception);
        }

    }
}
