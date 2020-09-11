<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl">
    <xsl:output method="html" indent="yes"/>

    <xsl:template match="/authorization">
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
				</style >
			</head>
			<body>
				<div>
					<h3>New Authorization</h3>
					<p>
						The new <xsl:value-of select ="fundingSource"/> authorization number <xsl:value-of select ="authorizationNo"/> for Program <xsl:value-of select="programName"/> must be reviewed, services assigned and approved.
					</p>
					<xsl:apply-templates select="service" />
					<p>
						<a href="{link}">Approve Authorization</a>
					</p>
				</div>		
			</body>	
		</html>
		
	</xsl:template>

	<xsl:template match="service">
		<table>
			<tr>
				<th colspan="2">
					Service
				</th>
			</tr>
		<tr>
			<th>Service Name</th>
			<td><xsl:value-of select="serviceName"/></td>
		</tr>
		<tr>
			<th>Number Of Units</th>
			<td><xsl:value-of select="numberOfUnits"/></td>
		</tr>
		<tr>
			<th>Unit</th>
			<td><xsl:value-of select="unitType"/></td>
		</tr>
		<tr>
			<th>Schedual Start Date</th>
			<td><xsl:value-of select="schedualStartDate"/></td>
		</tr>
		<tr>
			<th>Schedual End Date</th>
			<td><xsl:value-of select="schedualEndDate"/></td>
		</tr>
		</table>
	</xsl:template>
</xsl:stylesheet>
