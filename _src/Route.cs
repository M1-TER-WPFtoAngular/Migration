using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.Windows.Markup;


namespace MigrationTool {
    public class Route {

        private string url;
        private string componentName;


        public Route(string url, string componentName) {
            this.url = url;
            this.componentName = componentName;
        }

        public string getUrl() { return url;}
        public string getComponent() { return componentName;}

        public Route setUrl(string url) { this.url = url; return this;}
        public Route setComponent(string componentName) { this.componentName = componentName;return this;}

    }
}