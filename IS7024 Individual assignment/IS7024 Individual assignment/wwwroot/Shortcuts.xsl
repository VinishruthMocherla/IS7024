<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:template match="/">
    <html>
      <head>
        <meta charset="utf-8"/>
        <title>Favourite Shortcuts</title>
      </head>
      <body>
        <div>
          <h1>My team member's favourite shortcuts</h1>
          <table border="1" width="100%">
            <tr>
              <th>First name</th>
              <th>Last name</th>
              <th>BearCat ID</th>
              <th>Favorite shortcut</th>
            </tr>
            <xsl:for-each select="/users/user">
              <tr>
                <td>
                  <xsl:value-of select="firstname"/>
                </td>
                <td>
                  <xsl:value-of select="lastname"/>
                </td>
                <td>
                  <xsl:value-of select="bearcatid"/>
                </td>
                <td>
                  <xsl:value-of select="favoriteshortcut"/>
                </td>
              </tr>
            </xsl:for-each>
          </table>
        </div>

      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>