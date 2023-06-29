<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
<xsl:template match="/">
<html> 
<body>
<h2>Каталог аптек міста Енергодар</h2>
  <table border="1">
    <tr bgcolor="#9acd32">
      <th style="text-align:left">Назва аптеки</th>
      <th style="text-align:left">Адресса розташування</th>
      <th style="text-align:left">Кількість медикаментів</th>
      <th style="text-align:left">Кількість працівників</th>
      <th style="text-align:left">Статус</th>
      <th style="text-align:left">Форма роботи</th>
      <th style="text-align:left">Час роботи</th>
    </tr>
    <xsl:for-each select="catalog/pharmacy">
    <tr>
      <td><xsl:value-of select="name"/></td>
      <td><xsl:value-of select="address"/></td>
      <td><xsl:value-of select="medicines"/></td>
      <td><xsl:value-of select="employee-count"/></td>
      <td><xsl:value-of select="status"/></td>
      <td><xsl:value-of select="working-mode"/></td>
      <td><xsl:value-of select="working-time"/></td>
    </tr>
    </xsl:for-each>
  </table>
  <h2>Каталог відкритих аптек міста Енергодар</h2>
  <table border="1">
    <tr bgcolor="#9acd32">
      <th style="text-align:left">Назва аптеки</th>
      <th style="text-align:left">Адресса розташування</th>
      <th style="text-align:left">Кількість медикаментів</th>
      <th style="text-align:left">Кількість працівників</th>
      <th style="text-align:left">Статус</th>
      <th style="text-align:left">Форма роботи</th>
      <th style="text-align:left">Час роботи</th>
    </tr>
    <xsl:for-each select="catalog/pharmacy[status='Відчинено']">
    <tr>
      <td><xsl:value-of select="name"/></td>
      <td><xsl:value-of select="address"/></td>
      <td><xsl:value-of select="medicines"/></td>
      <td><xsl:value-of select="employee-count"/></td>
      <td><xsl:value-of select="status"/></td>
      <td><xsl:value-of select="working-mode"/></td>
      <td><xsl:value-of select="working-time"/></td>
    </tr>
    </xsl:for-each>
  </table>
</body>
</html>
</xsl:template>
</xsl:stylesheet>