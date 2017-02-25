namespace Photography
{
    using System;
    using System.Linq;
    using System.Xml.Linq;

    public class ExportXML
    {
        public static void Main()
        {
            var xDocument = CreateXDocument();
            xDocument.Save(@"..\..\photographs.xml");
            Console.WriteLine("Export photographs.xml complited!");
        }

        private static XDocument CreateXDocument()
        {
            var context = new PhotographyEntities();

            var photographs = context.Photographs
                .Select(
                    ph => new
                              {
                                  Title = ph.Title,
                                  Category = ph.Category.Name,
                                  Link = ph.Link,
                                  Equipment = new
                                                  {
                                                      CameraModel = ph.Equipment.Camera.Model,
                                                      CameraMegapixels = ph.Equipment.Camera.Megapixels,
                                                      LensName = ph.Equipment.Lens.Model,
                                                      LensPrice = ph.Equipment.Lens.Price
                                                  }
                              })
                .OrderBy(ph => ph.Title);

            var photographsNode = new XElement("photographs");

            foreach (var photograph in photographs)
            {
                var photographNode = new XElement(
                    "photograph",
                    new XAttribute("title", photograph.Title),
                    new XElement("category", photograph.Category),
                    new XElement("link", photograph.Link));

                var equipmentNode = new XElement("equipment");

                var cameraNode = new XElement("camera", photograph.Equipment.CameraModel);
                if (photograph.Equipment.CameraMegapixels != null)
                {
                    cameraNode.Add(new XAttribute("megapixels", photograph.Equipment.CameraMegapixels));
                }

                var lensNode = new XElement("lens", photograph.Equipment.LensName);
                if (photograph.Equipment.LensPrice != null)
                {
                    lensNode.Add(new XAttribute("price", photograph.Equipment.LensPrice));
                }

                equipmentNode.Add(cameraNode, lensNode);
                photographNode.Add(equipmentNode);
                photographsNode.Add(photographNode);
            }

            var xDocument = new XDocument(photographsNode);
            return xDocument;
        }
    }
}
