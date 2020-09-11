<?xml version="1.0"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl" xmlns:wa="urn:vgs:wa">
  <xsl:template match="/ProgramOutcome">
    <div>
      <h3>Work Adjustment Service Outcome</h3>
      <p>
        <strong>Accepting Authority</strong>
        <xsl:value-of  select ="AcceptingAuthority1"/>
      </p>
      <p>
        <strong>Accepting Authority2</strong>
        <xsl:value-of  select ="AcceptingAuthority2"/>
      </p>
      <p>
        <strong>Appearance1 </strong>
        <xsl:value-of  select ="Appearance1"/>
      </p>
      <p>
        <strong>Appearance2 </strong>
        <xsl:value-of  select ="Appearance2"/>
      </p>
      <p>
        <strong>Attendance1 </strong>
        <xsl:value-of  select ="Attendance1"/>
      </p>
      <p>
        <strong>Attendance2 </strong>
        <xsl:value-of  select ="Attendance2"/>
      </p>
      <p>
        <strong>On-Task Behavior1 </strong>
        <xsl:value-of  select ="OnTaskBehavior1"/>
      </p>
      <p>
        <strong>On-Task Behavior2 </strong>
        <xsl:value-of  select ="OnTaskBehavior2"/>
      </p>
      <p>
        <strong>Productivity1 </strong>
        <xsl:value-of  select ="Productivity1"/>
      </p>
      <p>
        <strong>Productivity2 </strong>
        <xsl:value-of  select ="Productivity2"/>
      </p>
      <p>
        <strong>Punctuality1 </strong>
        <xsl:value-of  select ="Punctuality1"/>
      </p>
      <p>
        <strong>Punctuality2 </strong>
        <xsl:value-of  select ="Punctuality2"/>
      </p>
      <p>
        <strong>WorkQuality1 </strong>
        <xsl:value-of  select ="WorkQuality1"/>
      </p>
      <p>
        <strong>WorkQuality2 </strong>
        <xsl:value-of  select ="WorkQuality2"/>
      </p>
      <p>
        <strong>Score 1 </strong>
        <xsl:value-of  select ="waScore1"/>
      </p>
      <p>
        <strong>Score 2 </strong>
        <xsl:value-of  select ="  waScore2"/>
      </p>
    </div>
  </xsl:template>
</xsl:stylesheet>
