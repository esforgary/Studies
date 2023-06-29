<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
<xsl:template match="/">
<html> 
<body>
  <h2>Список працівників</h2>
  <table border="1">
    <tr bgcolor="#9acd32">
      <th style="text-align:left">Посада</th>
      <th style="text-align:left">Ім'я</th>
      <th style="text-align:left">Вік</th>
      <th style="text-align:left">Контактний номер</th>
    </tr>
    <xsl:for-each select="catalog/employee">
    <tr>            
      <td>
        <xsl:if test="job-title = 'Адміністратор'">
          <span style="bgcolor:#EE9B00"><xsl:value-of select="job-title"/></span>
        </xsl:if>
        <xsl:if test="job-title = 'Прибиральниця'">
          <span style="bgcolor:#9B2226"><xsl:value-of select="job-title"/></span>
        </xsl:if>
        <xsl:if test="job-title = 'Фармацевт'">
          <span style="bgcolor:#0A9396"><xsl:value-of select="job-title"/></span>
        </xsl:if>
      </td>
      <td><xsl:value-of select="name"/></td>
      <td><xsl:value-of select="age"/></td>
      <td><xsl:value-of select="phone"/></td>
    </tr>
    </xsl:for-each>
  </table>
</body>
</html>
</xsl:template>
</xsl:stylesheet>