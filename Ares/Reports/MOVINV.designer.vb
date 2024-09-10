<?xml version="1.0" encoding="utf-8"?>
<XtraReportsLayoutSerializer SerializerVersion="16.1.4.0" Ref="1" ControlType="DevExpress.XtraReports.UI.XtraReport, DevExpress.XtraReports.v16.1, Version=16.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Name="XtraReportMOVINV" SnapGridSize="25" ReportUnit="TenthsOfAMillimeter" Margins="64, 1537, 380, 56" PageWidth="2159" PageHeight="2794" Version="16.1" DataMember="tblMovInv" DataSource="#Ref-0" Dpi="254">
  <Bands>
    <Item1 Ref="2" ControlType="DetailBand" Name="Detail" HeightF="71.0478439" TextAlignment="TopLeft" Dpi="254" Padding="0,0,0,0,254">
      <Controls>
        <Item1 Ref="3" ControlType="XRLabel" Name="XrLabel12" Text="XrLabel12" TextAlignment="MiddleCenter" SizeF="159.844879,34.9682846" LocationFloat="397.294281, 34.9683" Dpi="254" Font="Tahoma, 6.75pt" Padding="5,5,0,0,254">
          <DataBindings>
            <Item1 Ref="4" FormatString="{0:Q0.00}" PropertyName="Text" DataMember="tblMovInv.TOTALCOSTO" />
          </DataBindings>
          <StylePriority Ref="5" UseFont="false" UseTextAlignment="false" />
        </Item1>
        <Item2 Ref="6" ControlType="XRLabel" Name="XrLabel11" Text="XrLabel11" TextAlignment="MiddleCenter" SizeF="87.9213257,34.9683" LocationFloat="309.372955, 34.9683" Dpi="254" Font="Tahoma, 6.75pt" Padding="5,5,0,0,254">
          <DataBindings>
            <Item1 Ref="7" FormatString="{0:n2}" PropertyName="Text" DataMember="tblMovInv.COSTO" />
          </DataBindings>
          <StylePriority Ref="8" UseFont="false" UseTextAlignment="false" />
        </Item2>
        <Item3 Ref="9" ControlType="XRLabel" Name="XrLabel10" Text="XrLabel10" TextAlignment="MiddleCenter" SizeF="62.86841,34.9683" LocationFloat="246.504562, 34.9683" Dpi="254" Font="Tahoma, 6.75pt" Padding="5,5,0,0,254">
          <DataBindings>
            <Item1 Ref="10" PropertyName="Text" DataMember="tblMovInv.CANTIDAD" />
          </DataBindings>
          <StylePriority Ref="11" UseFont="false" UseTextAlignment="false" />
        </Item3>
        <Item4 Ref="12" ControlType="XRLabel" Name="XrLabel9" Text="XrLabel9" TextAlignment="MiddleCenter" SizeF="89.00008,34.9683" LocationFloat="157.504486, 34.9683" Dpi="254" Font="Tahoma, 6.75pt" Padding="5,5,0,0,254">
          <DataBindings>
            <Item1 Ref="13" PropertyName="Text" DataMember="tblMovInv.CODMEDIDA" />
          </DataBindings>
          <StylePriority Ref="14" UseFont="false" UseTextAlignment="false" />
        </Item4>
        <Item5 Ref="15" ControlType="XRLabel" Name="XrLabel8" Text="XrLabel8" TextAlignment="MiddleLeft" SizeF="558.8608,34.9683075" LocationFloat="0, 0" Dpi="254" Font="Tahoma, 6.75pt" Padding="5,5,0,0,254">
          <DataBindings>
            <Item1 Ref="16" PropertyName="Text" DataMember="tblMovInv.DESPROD" />
          </DataBindings>
          <StylePriority Ref="17" UseFont="false" UseTextAlignment="false" />
        </Item5>
        <Item6 Ref="18" ControlType="XRLabel" Name="XrLabel5" Text="XrLabel5" TextAlignment="MiddleLeft" SizeF="161.0484,34.9683" LocationFloat="0, 34.9683" Dpi="254" Font="Tahoma, 6.75pt" Padding="5,5,0,0,254">
          <DataBindings>
            <Item1 Ref="19" PropertyName="Text" DataMember="tblMovInv.CODPROD" />
          </DataBindings>
          <StylePriority Ref="20" UseFont="false" UseTextAlignment="false" />
        </Item6>
      </Controls>
    </Item1>
    <Item2 Ref="21" ControlType="TopMarginBand" Name="TopMargin" HeightF="380.000244" TextAlignment="TopLeft" Dpi="254" Padding="0,0,0,0,254">
      <Controls>
        <Item1 Ref="22" ControlType="XRLabel" Name="XrLabel22" Text="Documento:" TextAlignment="MiddleLeft" SizeF="211.634552,55.2708359" LocationFloat="0, 97.3642044" Dpi="254" Font="Tahoma, 9pt, style=Bold" Padding="5,5,0,0,254">
          <StylePriority Ref="23" UseFont="false" UseTextAlignment="false" />
        </Item1>
        <Item2 Ref="24" ControlType="XRLabel" Name="XrLabel21" Text="Subtotal" TextAlignment="MiddleCenter" SizeF="157.262482,51.6631775" LocationFloat="397.294281, 279.629669" Dpi="254" Font="Tahoma, 9pt, style=Bold, Underline" Padding="5,5,0,0,254">
          <StylePriority Ref="25" UseFont="false" UseTextAlignment="false" />
        </Item2>
        <Item3 Ref="26" ControlType="XRLabel" Name="XrLabel20" Text="Costo" TextAlignment="MiddleCenter" SizeF="103.4223,51.6628723" LocationFloat="293.872, 279.6298" Dpi="254" Font="Tahoma, 9pt, style=Bold, Underline" Padding="5,5,0,0,254">
          <StylePriority Ref="27" UseFont="false" UseTextAlignment="false" />
        </Item3>
        <Item4 Ref="28" ControlType="XRLabel" Name="XrLabel18" Text="Medida" TextAlignment="MiddleCenter" SizeF="131.202667,51.6629333" LocationFloat="160.086914, 279.6298" Dpi="254" Font="Tahoma, 9pt, style=Bold, Underline" Padding="5,5,0,0,254">
          <StylePriority Ref="29" UseFont="false" UseTextAlignment="false" />
        </Item4>
        <Item5 Ref="30" ControlType="XRLabel" Name="XrLabel17" Text="Descripción" SizeF="380.7084,51.6628571" LocationFloat="0, 224.358871" Dpi="254" Font="Tahoma, 9pt, style=Bold, Underline" Padding="5,5,0,0,254">
          <StylePriority Ref="31" UseFont="false" />
        </Item5>
        <Item6 Ref="32" ControlType="XRLabel" Name="XrLabel16" Text="Código" TextAlignment="MiddleLeft" SizeF="160.0869,51.663147" LocationFloat="0, 279.629669" Dpi="254" Font="Tahoma, 9pt, style=Bold, Underline" Padding="5,5,0,0,254">
          <StylePriority Ref="33" UseFont="false" UseTextAlignment="false" />
        </Item6>
        <Item7 Ref="34" ControlType="XRLabel" Name="XrLabel7" Text="XrLabel7" TextAlignment="MiddleLeft" SizeF="199.844528,55.2708359" LocationFloat="210.773727, 97.3642044" Dpi="254" Font="Tahoma, 8pt, style=Bold" Padding="5,5,0,0,254">
          <DataBindings>
            <Item1 Ref="35" PropertyName="Text" DataMember="tblMovInv.CODDOC" />
          </DataBindings>
          <StylePriority Ref="36" UseFont="false" UseTextAlignment="false" />
        </Item7>
        <Item8 Ref="37" ControlType="XRLabel" Name="XrLabel6" Text="XrLabel6" TextAlignment="MiddleLeft" SizeF="146.5209,55.2708359" LocationFloat="410.618256, 97.3642044" Dpi="254" Font="Tahoma, 8pt, style=Bold" Padding="5,5,0,0,254">
          <DataBindings>
            <Item1 Ref="38" PropertyName="Text" DataMember="tblMovInv.CORRELATIVO" />
          </DataBindings>
          <StylePriority Ref="39" UseFont="false" UseTextAlignment="false" />
        </Item8>
        <Item9 Ref="40" ControlType="XRLabel" Name="XrLabel4" Text="XrLabel4" TextAlignment="MiddleLeft" SizeF="347.226257,55.27083" LocationFloat="209.912918, 152.63504" Dpi="254" Font="Tahoma, 8pt" Padding="5,5,0,0,254">
          <DataBindings>
            <Item1 Ref="41" FormatString="{0:d/MM/yyyy}" PropertyName="Text" DataMember="tblMovInv.FECHA" />
          </DataBindings>
          <StylePriority Ref="42" UseFont="false" UseTextAlignment="false" />
        </Item9>
        <Item10 Ref="43" ControlType="XRLabel" Name="XrLabel1" Text="XrLabel1" TextAlignment="MiddleCenter" SizeF="557.4792,84.87838" LocationFloat="0.52082175, 0" Dpi="254" Font="Tahoma, 12pt, style=Bold" Padding="5,5,0,0,254">
          <DataBindings>
            <Item1 Ref="44" PropertyName="Text" DataMember="tblMovInv.EMPNOMBRE" />
          </DataBindings>
          <StylePriority Ref="45" UseFont="false" UseTextAlignment="false" />
        </Item10>
      </Controls>
    </Item2>
    <Item3 Ref="46" ControlType="BottomMarginBand" Name="BottomMargin" HeightF="56" TextAlignment="TopLeft" Dpi="254" Padding="0,0,0,0,254" />
    <Item4 Ref="47" ControlType="ReportFooterBand" Name="ReportFooter" HeightF="396.830963" Dpi="254">
      <Controls>
        <Item1 Ref="48" ControlType="XRLabel" Name="XrLabel2" Text="No. Compra:" SizeF="422.125,67.89868" LocationFloat="0.5208153, 268.1475" Dpi="254" Font="Tahoma, 12pt, style=Bold" Padding="5,5,0,0,254">
          <StylePriority Ref="49" UseFont="false" />
        </Item1>
        <Item2 Ref="50" ControlType="XRPageBreak" Name="XrPageBreak1" LocationFloat="0, 366.750977" Dpi="254" />
        <Item3 Ref="51" ControlType="XRLabel" Name="XrLabel13" Text="Usuario:" SizeF="160.1876,55.27084" LocationFloat="0, 0" Dpi="254" Font="Tahoma, 9pt, style=Bold" Padding="5,5,0,0,254">
          <StylePriority Ref="52" UseFont="false" />
        </Item3>
        <Item4 Ref="53" ControlType="XRLabel" Name="XrLabel3" Text="XrLabel3" SizeF="336.0208,55.27084" LocationFloat="160.086914, 0" Dpi="254" Font="Tahoma, 9pt" Padding="5,5,0,0,254">
          <DataBindings>
            <Item1 Ref="54" PropertyName="Text" DataMember="tblMovInv.USUARIO" />
          </DataBindings>
          <StylePriority Ref="55" UseFont="false" />
        </Item4>
        <Item5 Ref="56" ControlType="XRLine" Name="XrLine1" LineWidth="3" SizeF="557.999939,5" LocationFloat="0, 349.618134" Dpi="254" />
        <Item6 Ref="57" ControlType="XRLabel" Name="XrLabel23" Text="XrLabel23" SizeF="558.8608,142.190918" LocationFloat="0, 125.956566" Dpi="254" Padding="5,5,0,0,254">
          <DataBindings>
            <Item1 Ref="58" PropertyName="Text" DataMember="tblMovInv.OBS" />
          </DataBindings>
        </Item6>
        <Item7 Ref="59" ControlType="XRLabel" Name="XrLabel24" Text="Observaciones:" SizeF="422.125,55.27084" LocationFloat="0, 70.68576" Dpi="254" Font="Tahoma, 9pt, style=Bold" Padding="5,5,0,0,254">
          <StylePriority Ref="60" UseFont="false" />
        </Item7>
      </Controls>
    </Item4>
  </Bands>
  <ObjectStorage>
    <Item1 ObjectType="DevExpress.XtraReports.Serialization.ObjectStorageInfo, DevExpress.XtraReports.v16.1" Ref="0" Content="~Xtra#NULL" Type="Ares.DataSetInventarios" />
  </ObjectStorage>
</XtraReportsLayoutSerializer>