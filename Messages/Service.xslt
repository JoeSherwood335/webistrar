<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
    <xsl:output method="html" indent="yes"/>

    <xsl:template match="/service">
		<html>
			<head>
				<style type="text/css">
					html{
					font-family: Verdana, sans-serif;
					color:#696969;

					}

					table{
					border-width: 0px;
					border-spacing: 0px;
					border-style: outset;
					border-color: #e8eef4;
					border-collapse: collapse;
					background-color: white;


					}

					th {
					border-width: 1px;
					padding: 1px;
					border-style: solid;
					border-color: #e8eef4;
					width:50%;
					background-color: #e8eef4;
					color:#696969;
					font-family: Verdana, sans-serif;
					text-align:left;
					}

					td {
					border-width: 1px;
					padding: 1px;
					border-style: solid;
					border-color: #e8eef4;
					width:50%;
					font-family: Verdana, sans-serif;
					color:#696969;
					}

					h3, table, p {
					margin: 5px 0px;
					color:#696969;
					}

					a{
					color:#034af3;
					}
				</style >
			</head>
			<body>
				<h3>New Service</h3>
					<p>
						A Service as been assigned to you by <xsl:value-of select="AssignedBy"/> for <xsl:value-of select="consumer"/>
					</p>

					<table>
						<tr>
							<th colspan="2">Service</th>
						</tr>
						<tr>
							<th>Name</th>
							<td>
								<xsl:value-of select="product"/>
							</td>
						</tr>
					</table>
					<p>
						<a href="{link}">View Service</a>
					</p>
					<table>
						<tr>
							<th colspan="2">Authorization</th>
						</tr>
						<tr>
							<th>ServiceName</th>
							<td>
								<xsl:value-of select="serviceName"/>
							</td>
						</tr>
						<tr>
							<th>Number Of Units</th>
							<td>
								<xsl:value-of select="numberOfUnits"/>
							</td>
						</tr>
						<tr>
							<th>Unit</th>
							<td>
								<xsl:value-of select="unitType"/>
							</td>
						</tr>
						<tr>
							<th>Schedual Start Date</th>
							<td>
								<xsl:value-of select="schedualStartDate"/>
							</td>
						</tr>
						<tr>
							<th>Schedual End Date</th>
							<td>
								<xsl:value-of select="schedualEndDate"/>
							</td>
						</tr>
					</table>
			</body>
		</html>
    </xsl:template>
</xsl:stylesheet>
