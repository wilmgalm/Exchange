<h1>Exchange Application</h1>
<p>Welcome to Exchange Application, built with:</p>
<ul>
  <li><a href='https://get.asp.net/'>ASP.NET Core</a> and <a href='https://msdn.microsoft.com/en-us/library/67ef8sbd.aspx'>C#</a> for cross-platform server-side code</li>
  <li><a href='https://angular.io/'>Angular</a> and <a href='http://www.typescriptlang.org/'>TypeScript</a> for client-side code</li>
  <li><a href='https://www.mongodb.com/'>MongoDB</a> as Database</li>
  <li><a href='http://getbootstrap.com/'>Bootstrap</a> for layout and styling</li>
</ul>
<p>To help you:</p>
<ul>
  <li><strong>You must start the DolarExchange.Rest project</strong> because all services are invoked to that project</li>
  <li><strong>You may have to adjust the file </strong> <code>DolarExchange.Web\ClientApp\src\environments\environment.ts</code> in order to connect the frond-end to back-end</li>
  <li><strong>Database Integration</strong>. I had used MongoDB as database, you should install robo3t in order to connect to that database: the conection string is: <code>mongodb://wilmgalm:10wil33dan@cluster0-shard-00-00.bysjb.mongodb.net:27017,cluster0-shard-00-01.bysjb.mongodb.net:27017,cluster0-shard-00-02.bysjb.mongodb.net:27017/myFirstDatabase?ssl=true&replicaSet=Cluster0-shard-0&authSource=admin&retryWrites=true&w=majority</code></li>
  <li><strong>Database Scripts</strong>, I had used just one Collection in Mongo DB  <code>EXCH_CURRENCY_TRANSACTIONS</code> The application is able to create that Collection if it does not exists, but if you would like create it: <code> db.createCollection("EXCH_CURRENCY_TRANSACTIONS")</code></li>
  <li><strong>I've added a SOAP UI project, if you would like test the services by yourself ExchangeProject-soapui-project.xml.zip</li>
</ul>
