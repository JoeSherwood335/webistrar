<?xml version='1.0'?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:a="urn:vgs:st">
			<xsl:template match="/">

				<h3>Service Outcome for Skills Training</h3>

				<p>
					<strong>Completed By</strong> <xsl:value-of select="a:ProgramOutcome/@CompletedBy"/> on <em><xsl:value-of select="a:ProgramOutcome/@ed"/></em>
				</p>
        <!--p>
					<strong>Pre Test</strong>	<xsl:value-of select="a:ProgramOutcome/a:PracticeName"/>
				</p-->
				<p>
					<strong>Pre TestScore</strong> <xsl:value-of select ="a:ProgramOutcome/a:PracticeScore" />
				</p>
        <!--p>
					<strong>Main Test Name</strong> <xsl:value-of select="a:ProgramOutcome/a:MainName"/>
				</p-->
				<p>
					<strong>Post TestScore</strong> <xsl:value-of select="a:ProgramOutcome/a:MainScore" />
				</p>
        <p>
          <strong>Sat for 3rd party exame</strong>
          <xsl:value-of select="a:ProgramOutcome/a:MainScore" />
        </p>
			</xsl:template>
</xsl:stylesheet>