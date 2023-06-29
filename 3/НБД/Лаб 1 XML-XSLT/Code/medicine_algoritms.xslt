<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
<xsl:template match="/">
<html> 
<body>
  <h2>Список медикаментів</h2>
  <table border="1">
    <tr bgcolor="#9acd32">
      <th style="text-align:left">Назва медикаменту</th>
      <th style="text-align:left">Кількість/Об'ем</th>
      <th style="text-align:left">Термін зберігання</th>
      <th style="text-align:left">Ціна</th>
    </tr>
    <xsl:for-each select="catalog/medicine">
    <xsl:sort select="name" order="ascending"/>
    <tr>
      <td><xsl:value-of select="name"/></td>
      <td>
      <xsl:choose>
        <xsl:when test="count != 0">
          <xsl:value-of select="count"/>
        </xsl:when>
        <xsl:otherwise>
          <xsl:value-of select="volume"/>
        </xsl:otherwise>
      </xsl:choose>
      </td>
      <td><xsl:value-of select="shelf-life"/></td>
      <td><xsl:value-of select="price"/></td>
    </tr>
    </xsl:for-each>    
  </table>
</body>
</html>
</xsl:template>
</xsl:stylesheet>