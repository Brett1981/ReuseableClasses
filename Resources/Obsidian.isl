<?xml version="1.0" encoding="utf-8"?>

<styleLibrary>
  <styleSets defaultStyleSet="Default">
    <styleSet name="Default" useOsThemes="False" useFlatMode="True">
      <componentStyles>
        <componentStyle name="UltraCalculator" buttonStyle="FlatBorderless" useOsThemes="False" useFlatMode="True">
          <properties>
            <property name="ImageTransparentColor">Transparent</property>
          </properties>
        </componentStyle>
        <componentStyle name="UltraDockManager">
          <properties>
            <property name="GroupPaneTabStyle">Flat</property>
          </properties>
        </componentStyle>
        <componentStyle name="UltraExplorerBar" viewStyle="Standard" useOsThemes="False" />
        <componentStyle name="UltraListView" headerStyle="Standard" />
        <componentStyle name="UltraTabbedMdiManager">
          <properties>
            <property name="TabStyle">Flat</property>
          </properties>
        </componentStyle>
        <componentStyle name="UltraTabControl" buttonStyle="FlatBorderless" useOsThemes="False" useFlatMode="True">
          <properties>
            <property name="Style">Flat</property>
          </properties>
        </componentStyle>
        <componentStyle name="UltraTabStripControl">
          <properties>
            <property name="Style">Flat</property>
          </properties>
        </componentStyle>
        <componentStyle name="UltraToolbarsManager" useOsThemes="False" useFlatMode="True" />
      </componentStyles>
      <styles>
        <style role="Base">
          <states>
            <state name="Normal" foreColor="DimGray" fontName="Arial" textVAlign="Middle"
                   themedElementAlpha="Transparent" />
          </states>
        </style>
        <style role="Button" buttonStyle="FlatBorderless">
          <states>
            <state name="Normal">
              <resources>
                <name>buttonObsidian_Normal</name>
              </resources>
            </state>
            <state name="HotTracked">
              <resources>
                <name>buttonObsidian_HotTracked</name>
              </resources>
            </state>
            <state name="Pressed">
              <resources>
                <name>buttonObsidian_Pressed</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="CalendarComboControlArea">
          <states>
            <state name="Normal" borderColor="LightGray" />
          </states>
        </style>
        <style role="ComboDropDownButton">
          <states>
            <state name="Normal" borderColor="Transparent" />
          </states>
        </style>
        <style role="DayViewAllDayEventArea">
          <states>
            <state name="Normal" backColor="WhiteSmoke" backGradientStyle="None" backHatchStyle="None" />
          </states>
        </style>
        <style role="DayViewControlArea">
          <states>
            <state name="Normal" backColor="White" borderColor="Transparent" backGradientStyle="None"
                   backHatchStyle="None" />
          </states>
        </style>
        <style role="DayViewTimeSlotNonWorkingHour">
          <states>
            <state name="Normal" backColor="WhiteSmoke" borderColor="Gainsboro" backGradientStyle="None" />
            <state name="Selected" backColor="WhiteSmoke" imageBackgroundStyle="Stretched" backGradientStyle="None" />
          </states>
        </style>
        <style role="DayViewTimeSlotWorkingHour">
          <states>
            <state name="Normal" backColor="LightGray" borderColor="Gainsboro" backGradientStyle="None"
                   backHatchStyle="None" />
            <state name="Selected" foreColor="White" fontBold="True">
              <resources>
                <name>sharedSilverObsidian</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="DockControlPaneContentArea">
          <states>
            <state name="Normal" backColor="White" backGradientStyle="None" backHatchStyle="None" />
          </states>
        </style>
        <style role="DockFloatingWindowCaptionHorizontal">
          <states>
            <state name="Normal">
              <resources>
                <name>headerObsidian_Normal</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="DockPaneCaptionHorizontal">
          <states>
            <state name="Normal">
              <resources>
                <name>headerObsidian_Normal</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="DockSlidingGroupHeaderHorizontal">
          <states>
            <state name="Normal">
              <resources>
                <name>headerObsidian_Normal</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="DockSlidingGroupHeaderVertical">
          <states>
            <state name="Normal">
              <resources>
                <name>headerObsidian_Normal</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="DropDownControlArea">
          <states>
            <state name="Normal" backColor="White" backGradientStyle="None" backHatchStyle="None" />
          </states>
        </style>
        <style role="EditorControl">
          <states>
            <state name="Normal">
              <resources>
                <name>backgroundObsidian</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="ExplorerBarControlArea">
          <states>
            <state name="Normal" borderColor="Transparent">
              <resources>
                <name>backgroundObsidian</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="ExplorerBarGroupHeader">
          <states>
            <state name="Normal">
              <resources>
                <name>explorerBarGroupHeaderObsidian_Normal</name>
              </resources>
            </state>
            <state name="HotTracked">
              <resources>
                <name>explorerBarGroupHeaderObsidian_HotTracked</name>
              </resources>
            </state>
            <state name="Active">
              <resources>
                <name>explorerBarGroupHeaderObsidian_Active</name>
              </resources>
            </state>
            <state name="EditMode" backColor="Transparent" backGradientStyle="None" backHatchStyle="None" />
          </states>
        </style>
        <style role="ExplorerBarGroupItemAreaInner">
          <states>
            <state name="Normal" borderColor="Transparent" imageBackgroundStyle="Stretched"
                   imageBackgroundStretchMargins="2, 1, 2, 2">
              <imageBackground>AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAA9wAAAAKJUE5HDQoaCgAAAA1JSERSAAAAJAAAABkIBgAAAFnkjOsAAAABc1JHQgCuzhzpAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAACXBIWXMAAAsQAAALEAGtI711AAAAYElEQVRIS+3XuQ3AMAxDUWWQINto/xW8SOhjALNl8QOwYiO8sPHT3X9VfSsJ36h9kKRKyMHhoMvfQMjtFCGEnIDr2RBCTsD1bAghJ+B6NoSQE3B97obWZW9IzqtDmyokms1RcvWWmZsaAAAAAElFTkSuQmCCCwAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=</imageBackground>
              <resources>
                <name>backgroundObsidian</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="ExplorerBarGroupItemAreaOuter" borderStyle="None">
          <states>
            <state name="Normal" borderColor="Transparent" />
          </states>
        </style>
        <style role="ExplorerBarItem">
          <states>
            <state name="Normal" backColor="Transparent" borderColor="Transparent" backGradientStyle="None"
                   backHatchStyle="None" />
            <state name="HotTracked" backColor="Transparent" borderColor="Transparent" imageBackgroundStyle="Stretched"
                   backGradientStyle="None" backHatchStyle="None" imageBackgroundStretchMargins="5, 2, 7, 4" />
          </states>
        </style>
        <style role="ExplorerBarNavigationOverflowButtonArea">
          <states>
            <state name="Normal">
              <resources>
                <name>backgroundObsidian</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="GridBandHeader">
          <states>
            <state name="Normal" backColor="Gainsboro" foreColor="DimGray" borderColor="Transparent" textHAlign="Left"
                   imageBackgroundStyle="Stretched" fontBold="True" fontSize="10" backColor2="White"
                   backGradientStyle="Vertical" imageBackgroundStretchMargins="5, 6, 6, 0" />
          </states>
        </style>
        <style role="GridCaption">
          <states>
            <state name="Normal" backColor="DimGray" foreColor="White" borderColor="Transparent" fontBold="True"
                   fontSize="11" backGradientStyle="None" backHatchStyle="None" />
          </states>
        </style>
        <style role="GridCell">
          <states>
            <state name="Normal" borderColor="Transparent" />
            <state name="Selected" borderColor="Transparent" />
            <state name="Active" backColor="Transparent" foreColor="30, 30, 30" borderColor="Transparent"
                   backGradientStyle="None" />
            <state name="EditMode" backColor="Transparent" imageBackgroundStyle="Stretched" backGradientStyle="None"
                   imageBackgroundStretchMargins="3, 6, 4, 6">
              <imageBackground>AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAAcQEAAAKJUE5HDQoaCgAAAA1JSERSAAAAQAAAABkIBgAAAIHoKOEAAAABc1JHQgCuzhzpAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAACXBIWXMAAArvAAAK7wF9dopIAAAA2klEQVRYR+2YsQ2EMAxFfXTZg9WAFmoKGICGMcIMmQJRIAENDSMgEOLf+ZBOuhn8LblJ934S++u/2rZFFEUyz7Ps+y4WyjkncRzLfd8i3nvUdY1t22ClpmlCWZZQdsnzHOu6WmH/cY7jiKIoIGmamoNX4Ou6kGWZXQFUBArAF8AvwBlgdgtwCHILcA3SB9AI0QjRCNEI0QhZzQP+nOAnGzMXihzH8fgAjcQ0HrJWfd8/kVjXdaiqCsMw4DxPEzosywK9eGWXJEnQNM33QOeBhVZWZVZ2CSHAcr8BPNL8TCRyd9cAAAAASUVORK5CYIILAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA==</imageBackground>
            </state>
          </states>
        </style>
        <style role="GridColumnHeader">
          <states>
            <state name="Normal" textHAlign="Left" fontBold="True" fontSize="10"
                   imageBackgroundStretchMargins="6, 3, 7, 7">
              <resources>
                <name>headerObsidian_Normal</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="GridControlArea">
          <states>
            <state name="Normal" backColor="White" borderColor="Transparent" backGradientStyle="None" />
          </states>
        </style>
        <style role="GridGroupByBox">
          <states>
            <state name="Normal" backColor="White" backGradientStyle="None" backHatchStyle="None" />
          </states>
        </style>
        <style role="GridGroupByBoxPrompt">
          <states>
            <state name="Normal" backColor="LightGray" backColor2="White" backGradientStyle="Horizontal" />
          </states>
        </style>
        <style role="GridHeader" borderStyle="None" />
        <style role="GridRow">
          <states>
            <state name="Normal" backColor="White" borderColor="Gainsboro" backGradientStyle="None"
                   backHatchStyle="None" />
            <state name="Selected" backColor="WhiteSmoke" foreColor="DimGray" backGradientStyle="None"
                   backHatchStyle="None" />
            <state name="Active">
              <resources>
                <name>sharedSilverObsidian</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="GridRowScrollRegionSplitBox">
          <states>
            <state name="Normal" backColor="White" backGradientStyle="None" backHatchStyle="None" />
          </states>
        </style>
        <style role="GridRowSelector">
          <states>
            <state name="Normal" backColor="DimGray" foreColor="White" borderColor="WhiteSmoke" imageHAlign="Right"
                   imageVAlign="Middle" backGradientStyle="None" backHatchStyle="None" />
            <state name="FilterRow" backColor="IndianRed" backGradientStyle="None" />
          </states>
        </style>
        <style role="GridRowSelectorHeader">
          <states>
            <state name="Normal" backColor="DimGray" backGradientStyle="None" backHatchStyle="None" />
          </states>
        </style>
        <style role="GroupPaneTabItemAreaHorizontalBottom">
          <states>
            <state name="Normal" backColor="White" backGradientStyle="None" backHatchStyle="None" />
          </states>
        </style>
        <style role="GroupPaneTabItemAreaVertical">
          <states>
            <state name="Normal">
              <resources>
                <name>backgroundObsidian</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="GroupPaneTabItemAreaVerticalRight">
          <states>
            <state name="Normal" backColor="White" backGradientStyle="None" backHatchStyle="None" />
          </states>
        </style>
        <style role="GroupPaneTabItemHorizontal">
          <states>
            <state name="Normal" backColor="White" foreColor="White" backColor2="DarkGray" backGradientStyle="Vertical" />
            <state name="Selected" backColor="White" backColor2="Black" backGradientStyle="Vertical" />
          </states>
        </style>
        <style role="GroupPaneTabItemHorizontalBottom">
          <states>
            <state name="Normal" backColor="White" backGradientStyle="None" backHatchStyle="None" />
          </states>
        </style>
        <style role="GroupPaneTabItemHorizontalTop">
          <states>
            <state name="Normal" backColor="White" borderColor="Transparent" backGradientStyle="None"
                   backHatchStyle="None" />
            <state name="Selected" backColor="Transparent" borderColor="Transparent" backGradientStyle="None"
                   backHatchStyle="None" />
          </states>
        </style>
        <style role="GroupPaneTabItemVertical">
          <states>
            <state name="Normal" backColor="White" foreColor="White" backColor2="Gray" backGradientStyle="Horizontal" />
            <state name="Selected" backColor="White" backColor2="Black" backGradientStyle="Horizontal" />
          </states>
        </style>
        <style role="GroupPaneTabItemVerticalLeft">
          <states>
            <state name="Normal" backColor="White" borderColor="Transparent" backGradientStyle="None"
                   backHatchStyle="None" />
            <state name="Selected" backColor="Transparent" borderColor="Transparent" backGradientStyle="None"
                   backHatchStyle="None" />
          </states>
        </style>
        <style role="GroupPaneTabItemVerticalRight">
          <states>
            <state name="Normal" backColor="Transparent" borderColor="Transparent" backGradientStyle="None"
                   backHatchStyle="None" />
          </states>
        </style>
        <style role="ListViewColumnHeader">
          <states>
            <state name="Normal" borderColor="Transparent">
              <resources>
                <name>backgroundObsidian</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="ListViewControlArea">
          <states>
            <state name="Normal" borderColor="Gainsboro" />
          </states>
        </style>
        <style role="ListViewGroupHeader">
          <states>
            <state name="Normal" backColor="45, 45, 45" foreColor="White" borderColor="Transparent" fontBold="True"
                   backColor2="White" backGradientStyle="Horizontal" />
          </states>
        </style>
        <style role="MainMenubarHorizontal">
          <states>
            <state name="Normal">
              <resources>
                <name>backgroundObsidian</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="MaskPromptChar">
          <states>
            <state name="Normal" borderColor="Silver" />
          </states>
        </style>
        <style role="MenuItemAddRemoveTool">
          <states>
            <state name="Normal" backColor="White" backGradientStyle="None" />
          </states>
        </style>
        <style role="ProgressBarFill">
          <states>
            <state name="Normal">
              <resources>
                <name>progressBarFillObsidian_Normal</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="ScheduleAppointment">
          <states>
            <state name="Normal" backColor="WhiteSmoke" backGradientStyle="None" backHatchStyle="None" />
            <state name="Selected" backColor="DimGray" foreColor="White" backColor2="Black"
                   backGradientStyle="Vertical" />
          </states>
        </style>
        <style role="ScheduleCurrentDayHeader">
          <states>
            <state name="Normal" backColor="Black" foreColor="White" backColor2="DimGray" backGradientStyle="Vertical" />
          </states>
        </style>
        <style role="ScheduleDay">
          <states>
            <state name="Normal" foreColor="DimGray" borderColor="Gainsboro" />
            <state name="Selected" backColor="Black" foreColor="White" backGradientStyle="None" backHatchStyle="None" />
          </states>
        </style>
        <style role="ScheduleDayHeader">
          <states>
            <state name="Normal" backColor="180, 180, 180" foreColor="White" fontBold="True" backGradientStyle="None"
                   backHatchStyle="None" />
            <state name="Selected" backColor="DimGray" imageBackgroundStyle="Stretched" fontBold="True"
                   backColor2="Black" backGradientStyle="Vertical" />
          </states>
        </style>
        <style role="ScheduleDayOfWeekHeader">
          <states>
            <state name="Normal" backColor="White" foreColor="Black" borderColor="Gainsboro" fontBold="True"
                   backGradientStyle="None" backHatchStyle="None" />
          </states>
        </style>
        <style role="ScheduleMonthHeader">
          <states>
            <state name="Normal">
              <resources>
                <name>headerObsidian_Normal</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="ScheduleOwner">
          <states>
            <state name="Normal" backColor="Transparent" borderColor="Transparent" backGradientStyle="None" />
          </states>
        </style>
        <style role="ScheduleOwnerHeader">
          <states>
            <state name="Normal" backColor="Transparent" borderColor="Transparent" imageBackgroundStyle="Stretched"
                   backGradientStyle="None" imageBackgroundStretchMargins="3, 3, 5, 3">
              <resources>
                <name>headerObsidian_Normal</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="ScheduleWeekHeader">
          <states>
            <state name="Normal" backColor="White" backGradientStyle="None" backHatchStyle="None" />
          </states>
        </style>
        <style role="ScrollBarArrowUp">
          <states>
            <state name="Normal" backColor="Transparent" backGradientStyle="None" />
            <state name="Pressed" backColor="Transparent" backGradientStyle="None" />
          </states>
        </style>
        <style role="ScrollBarHorizontal">
          <states>
            <state name="Normal" imageBackgroundStyle="Stretched" imageBackgroundStretchMargins="11, 0, 12, 0" />
          </states>
        </style>
        <style role="ScrollBarThumbHorizontal">
          <states>
            <state name="Normal">
              <resources>
                <name>scrollBarThumbHorizontalObsidian_Normal</name>
              </resources>
            </state>
            <state name="HotTracked">
              <resources>
                <name>scrollBarThumbHorizontalObsidian_HotTracked</name>
              </resources>
            </state>
            <state name="Pressed">
              <resources>
                <name>scrollBarThumbHorizontalObsidian_Pressed</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="ScrollBarThumbVertical">
          <states>
            <state name="Normal">
              <resources>
                <name>scrollBarThumbVerticalObsidian_Normal</name>
              </resources>
            </state>
            <state name="HotTracked">
              <resources>
                <name>scrollBarThumbVerticalObsidian_HotTracked</name>
              </resources>
            </state>
            <state name="Pressed">
              <resources>
                <name>scrollBarThumbVerticalObsidian_Pressed</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="ScrollBarTrackHorizontal">
          <states>
            <state name="Normal">
              <resources>
                <name>scrollBarTrackHorizontalObsidian_Normal</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="ScrollBarTrackSectionBottom">
          <states>
            <state name="Normal" imageBackgroundStyle="Stretched" imageBackgroundStretchMargins="0, 0, 0, 8" />
          </states>
        </style>
        <style role="ScrollBarTrackSectionTop">
          <states>
            <state name="Normal" imageBackgroundStyle="Stretched" imageBackgroundStretchMargins="0, 7, 0, 0" />
          </states>
        </style>
        <style role="ScrollBarTrackVertical">
          <states>
            <state name="Normal">
              <resources>
                <name>scrollBarTrackVerticalObsidian_Normal</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="ScrollBarVertical">
          <states>
            <state name="Normal" backColor="White" imageBackgroundStyle="Stretched" backGradientStyle="None"
                   backHatchStyle="None" imageBackgroundStretchMargins="0, 12, 0, 12" />
          </states>
        </style>
        <style role="SpinButtonUp">
          <states>
            <state name="Normal" foreColor="White" />
          </states>
        </style>
        <style role="SpinButtonUpMinValue">
          <states>
            <state name="Normal" foreColor="White" />
          </states>
        </style>
        <style role="StatusBarPanel">
          <states>
            <state name="Normal">
              <resources>
                <name>backgroundObsidian</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="StatusBarProgressBar">
          <states>
            <state name="Normal">
              <resources>
                <name>ultraProgressBarObsidian_Normal</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="TabControlClientArea">
          <states>
            <state name="Normal" borderColor="51, 51, 51" imageBackgroundStyle="Stretched"
                   imageBackgroundStretchMargins="0, 16, 0, 0" />
          </states>
        </style>
        <style role="TabControlClientAreaHorizontal">
          <states>
            <state name="Normal" backColor="White" backGradientStyle="None" backHatchStyle="None" />
          </states>
        </style>
        <style role="TabControlTabsAreaHorizontalTop">
          <states>
            <state name="Normal" backColor="White" backGradientStyle="None" backHatchStyle="None">
              <resources>
                <name>backgroundObsidian</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="TabControlTabsAreaVerticalLeft">
          <states>
            <state name="Normal" backColor="WhiteSmoke" backGradientStyle="None" />
          </states>
        </style>
        <style role="TabControlTabsAreaVerticalRight">
          <states>
            <state name="Normal" backColor="White" backGradientStyle="None" backHatchStyle="None" />
          </states>
        </style>
        <style role="TabItemHorizontalBottom">
          <states>
            <state name="Normal">
              <resources>
                <name>tabItemHorizontalBottomObsidian_Normal</name>
              </resources>
            </state>
            <state name="Selected">
              <resources>
                <name>tabItemHorizontalBottomObsidian_Selected</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="TabItemHorizontalTop">
          <states>
            <state name="Normal">
              <resources>
                <name>tabItemHorizontalTopObsidian_Normal</name>
              </resources>
            </state>
            <state name="Selected">
              <resources>
                <name>tabItemHorizontalTopObsidian_Selected</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="TabItemVerticalLeft">
          <states>
            <state name="Normal">
              <resources>
                <name>tabItemVerticalLeftObsidian_Normal</name>
              </resources>
            </state>
            <state name="Selected">
              <resources>
                <name>tabItemVerticalLeftObsidian_Selected</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="TabItemVerticalRight">
          <states>
            <state name="Normal">
              <resources>
                <name>tabItemVerticalRightObsidian_Normal</name>
              </resources>
            </state>
            <state name="Selected">
              <resources>
                <name>tabItemVerticalRightObsidian_Selected</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="TaskPaneToolbar">
          <states>
            <state name="Normal">
              <resources>
                <name>headerObsidian_Normal</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="TaskPaneToolbarMenu">
          <states>
            <state name="Normal" borderColor="Transparent" />
          </states>
        </style>
        <style role="ToolbarCloseButton">
          <states>
            <state name="Normal" foreColor="DimGray" fontBold="True">
              <resources>
                <name>buttonObsidian_Normal</name>
              </resources>
            </state>
            <state name="HotTracked">
              <resources>
                <name>buttonObsidian_HotTracked</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="ToolbarDockAreaFloating">
          <states>
            <state name="Normal" backColor="White" backGradientStyle="None" />
          </states>
        </style>
        <style role="ToolbarDockAreaTop">
          <states>
            <state name="Normal" borderColor="Transparent">
              <resources>
                <name>backgroundObsidian</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="ToolbarFloatingCaption">
          <states>
            <state name="Normal">
              <resources>
                <name>headerObsidian_Normal</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="ToolbarGrabHandle">
          <states>
            <state name="Normal">
              <resources>
                <name>backgroundObsidian</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="ToolbarHorizontal">
          <states>
            <state name="Normal">
              <resources>
                <name>backgroundObsidian</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="ToolbarItem">
          <states>
            <state name="Normal">
              <resources>
                <name>backgroundObsidian</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="ToolbarItemButton">
          <states>
            <state name="Normal">
              <resources>
                <name>backgroundObsidian</name>
              </resources>
            </state>
            <state name="HotTracked" borderColor="Transparent">
              <resources>
                <name>backgroundObsidian_hover</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="ToolbarItemFontList">
          <states>
            <state name="Normal" borderColor="Transparent">
              <resources>
                <name>backgroundObsidian</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="ToolbarItemLabel">
          <states>
            <state name="Normal">
              <resources>
                <name>backgroundObsidian</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="ToolbarItemMaskedEdit">
          <states>
            <state name="HotTracked">
              <resources>
                <name>backgroundObsidian_hover</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="ToolbarItemPopupColorPicker">
          <states>
            <state name="Normal">
              <resources>
                <name>backgroundObsidian</name>
              </resources>
            </state>
            <state name="HotTracked">
              <resources>
                <name>backgroundObsidian_hover</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="ToolbarItemPopupControlContainer">
          <states>
            <state name="HotTracked" borderColor="Transparent">
              <resources>
                <name>backgroundObsidian_hover</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="ToolbarItemPopupMenu">
          <states>
            <state name="Normal">
              <resources>
                <name>backgroundObsidian</name>
              </resources>
            </state>
            <state name="HotTracked">
              <resources>
                <name>backgroundObsidian_hover</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="ToolbarItemQuickCustomize">
          <states>
            <state name="Normal" foreColor="Black" />
            <state name="HotTracked" backColor="Transparent" borderColor="Transparent" backGradientStyle="None"
                   backHatchStyle="None" />
            <state name="Pressed" imageBackgroundStyle="Stretched" imageBackgroundStretchMargins="4, 4, 4, 4">
              <imageBackground>AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAAegEAAAKJUE5HDQoaCgAAAA1JSERSAAAAFgAAABQIBgAAAIl8zTAAAAABc1JHQgCuzhzpAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAACXBIWXMAAAsQAAALEAGtI711AAAA40lEQVQ4T7WVMQuDMBBG7R9s+zPd1U3BRRAlRRBBEERwlBCnKrTlay6tKXSrvQhvvMcRzMsBgOfkC8PQ05w1F81Dc9PcdyL03Imcm/Tati2klJjneRfTNKFpGmipIrmXJAmEEBiGgYWiKBDHMWhjVFWFuq5ZIBc5jbgsS1asOM9zcGLFWZaBE/cb+74PTuzGQRCAEyumf5kT92fMdTk2j9246zpwYsRRFJlGjOPIQt/3ryudpqmp0t6qfc9RK8hJrThqJMmVUliWBeu6/gzN0hm/O34i8SanSFPo/+ETenqaXPAEvtFyAQWxeMIAAAAASUVORK5CYIILAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA==</imageBackground>
            </state>
            <state name="Active" borderColor="Transparent" />
          </states>
        </style>
        <style role="ToolbarItemStateButton">
          <states>
            <state name="HotTracked" backColor="Transparent" backGradientStyle="None" backHatchStyle="None" />
          </states>
        </style>
        <style role="ToolbarItemTaskPaneLabel">
          <states>
            <state name="Normal" backColor="Transparent" foreColor="White" borderColor="White" backGradientStyle="None"
                   backHatchStyle="None" />
          </states>
        </style>
        <style role="ToolbarItemTaskPaneMenuDropDownOnly">
          <states>
            <state name="Normal">
              <resources>
                <name>buttonObsidian_Normal</name>
              </resources>
            </state>
            <state name="HotTracked">
              <resources>
                <name>buttonObsidian_HotTracked</name>
              </resources>
            </state>
            <state name="Pressed">
              <resources>
                <name>buttonObsidian_Pressed</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="ToolbarItemTaskPaneNavigationBack">
          <states>
            <state name="Normal" foreColor="White">
              <resources>
                <name>buttonObsidian_Normal</name>
              </resources>
            </state>
            <state name="HotTracked">
              <resources>
                <name>buttonObsidian_HotTracked</name>
              </resources>
            </state>
            <state name="Pressed">
              <resources>
                <name>buttonObsidian_Pressed</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="ToolbarItemTaskPaneNavigationForward">
          <states>
            <state name="Normal">
              <resources>
                <name>buttonObsidian_Normal</name>
              </resources>
            </state>
            <state name="HotTracked">
              <resources>
                <name>buttonObsidian_HotTracked</name>
              </resources>
            </state>
            <state name="Pressed">
              <resources>
                <name>buttonObsidian_Pressed</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="ToolbarItemTextBox">
          <states>
            <state name="HotTracked" borderColor="Transparent">
              <resources>
                <name>backgroundObsidian_hover</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="TreeColumnHeader">
          <states>
            <state name="Normal" borderColor="Transparent">
              <resources>
                <name>backgroundObsidian</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="TreeControlArea">
          <states>
            <state name="Normal" borderColor="Gainsboro" />
          </states>
        </style>
        <style role="UltraCalculator">
          <states>
            <state name="Normal">
              <resources>
                <name>backgroundObsidian</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="UltraCalculatorButton">
          <states>
            <state name="Normal" foreColor="DimGray" />
            <state name="HotTracked" foreColor="White" />
          </states>
        </style>
        <style role="UltraCalculatorButtonAction">
          <states>
            <state name="Normal" backColor="Transparent" backGradientStyle="None" backHatchStyle="None" />
          </states>
        </style>
        <style role="UltraCalculatorButtonImmediateAction">
          <states>
            <state name="Normal" backColor="Transparent" backGradientStyle="None" backHatchStyle="None" />
          </states>
        </style>
        <style role="UltraCalculatorButtonOperator">
          <states>
            <state name="Normal" backColor="Transparent" backGradientStyle="None" backHatchStyle="None" />
          </states>
        </style>
        <style role="UltraCalculatorButtonPendingCalculations">
          <states>
            <state name="Normal" backColor="Transparent" backGradientStyle="None" backHatchStyle="None" />
          </states>
        </style>
        <style role="UltraGroupBox">
          <states>
            <state name="Normal" backColor="White" backGradientStyle="None" backHatchStyle="None" />
          </states>
        </style>
        <style role="UltraGroupBoxContentArea">
          <states>
            <state name="Normal" backColor="White" backGradientStyle="None" backHatchStyle="None" />
          </states>
        </style>
        <style role="UltraGroupBoxHeaderHorizontalTop">
          <states>
            <state name="Normal" backColor="White" backGradientStyle="None" backHatchStyle="None" />
          </states>
        </style>
        <style role="UltraProgressBar">
          <states>
            <state name="Normal">
              <resources>
                <name>ultraProgressBarObsidian_Normal</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="UltraTextEditor">
          <states>
            <state name="Normal" borderColor="Transparent">
              <resources>
                <name>backgroundObsidian</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="UnpinnedTabAreaBottom">
          <states>
            <state name="Normal" backColor="White" backGradientStyle="None" backHatchStyle="None" />
          </states>
        </style>
        <style role="UnpinnedTabAreaLeft">
          <states>
            <state name="Normal" backColor="White" backGradientStyle="None" backHatchStyle="None" />
          </states>
        </style>
        <style role="UnpinnedTabAreaRight">
          <states>
            <state name="Normal" backColor="White" backGradientStyle="None" backHatchStyle="None" />
          </states>
        </style>
        <style role="UnpinnedTabAreaTop">
          <states>
            <state name="Normal" backColor="White" backGradientStyle="None" backHatchStyle="None" />
          </states>
        </style>
        <style role="UnpinnedTabItemHorizontal">
          <states>
            <state name="Normal">
              <resources>
                <name>headerObsidian_Normal</name>
              </resources>
            </state>
          </states>
        </style>
        <style role="UnpinnedTabItemHorizontalBottom">
          <states>
            <state name="Normal" backColor="White" borderColor="Transparent" backGradientStyle="None"
                   backHatchStyle="None" />
          </states>
        </style>
        <style role="UnpinnedTabItemHorizontalTop">
          <states>
            <state name="Normal" backColor="White" borderColor="Transparent" backGradientStyle="None"
                   backHatchStyle="None" />
          </states>
        </style>
        <style role="UnpinnedTabItemVerticalLeft">
          <states>
            <state name="Normal" backColor="White" borderColor="Transparent" backGradientStyle="None"
                   backHatchStyle="None" />
          </states>
        </style>
        <style role="UnpinnedTabItemVerticalRight">
          <states>
            <state name="Normal" borderColor="Transparent" />
            <state name="Selected" backColor="Transparent" backGradientStyle="None" backHatchStyle="None" />
          </states>
        </style>
        <style role="WeekViewControlArea">
          <states>
            <state name="Normal" borderColor="Transparent" />
          </states>
        </style>
      </styles>
      <sharedObjects>
        <sharedObject name="ScrollBar">
          <properties>
            <property name="MinimumThumbExtent">20</property>
            <property name="MinimumThumbHeight">25</property>
            <property name="MinimumThumbWidth">25</property>
          </properties>
        </sharedObject>
      </sharedObjects>
    </styleSet>
  </styleSets>
  <resources>
    <resource name="backgroundObsidian" backColor="White" borderColor="LightGray" backColor2="Gainsboro"
              backGradientStyle="Vertical" />
    <resource name="backgroundObsidian_hover" backColor="75, 75, 75" foreColor="Black" borderColor="Transparent"
              backColor2="White" backGradientStyle="Vertical" />
    <resource name="buttonObsidian_HotTracked" backColor="Transparent" foreColor="Gray" borderColor="Transparent"
              imageBackgroundStyle="Stretched" backGradientStyle="None" backHatchStyle="None"
              imageBackgroundStretchMargins="4, 4, 5, 4">
      <imageBackground>AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAAegEAAAKJUE5HDQoaCgAAAA1JSERSAAAAFgAAABQIBgAAAIl8zTAAAAABc1JHQgCuzhzpAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAACXBIWXMAAAsQAAALEAGtI711AAAA40lEQVQ4T7WVMQuDMBBG7R9s+zPd1U3BRRAlRRBBEERwlBCnKrTlay6tKXSrvQhvvMcRzMsBgOfkC8PQ05w1F81Dc9PcdyL03Imcm/Tati2klJjneRfTNKFpGmipIrmXJAmEEBiGgYWiKBDHMWhjVFWFuq5ZIBc5jbgsS1asOM9zcGLFWZaBE/cb+74PTuzGQRCAEyumf5kT92fMdTk2j9246zpwYsRRFJlGjOPIQt/3ryudpqmp0t6qfc9RK8hJrThqJMmVUliWBeu6/gzN0hm/O34i8SanSFPo/+ETenqaXPAEvtFyAQWxeMIAAAAASUVORK5CYIILAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA==</imageBackground>
    </resource>
    <resource name="buttonObsidian_Normal" backColor="Transparent" foreColor="White" borderColor="Transparent"
              imageBackgroundStyle="Stretched" backGradientStyle="None" imageBackgroundStretchMargins="4, 4, 5, 4">
      <imageBackground>AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAAgwEAAAKJUE5HDQoaCgAAAA1JSERSAAAAFgAAABQIBgAAAIl8zTAAAAABc1JHQgCuzhzpAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAACXBIWXMAAAsQAAALEAGtI711AAAA7ElEQVQ4T7WVy2qEQBBFnR+cmY/VnQiCWyP4whe4EhUcAipxEeWm7wz2QHYxZcNZ1uFSULcvAIxTnmmahuKu+FBsim/FehBfzd3o3KVfVVVhnmcsy3KIcRyR5zmU9JNyw3EchGGIvu9FCIIAdBqWZaEsS9R1LUJRFEwNrgJZlomixWmaQhItjuMYkpyf2LZtSKITe54HSbTY931Icu6OeSBSx7F7nokpbppGFC3uug7DMIjQtu3rpF3XfbbS0Vb7PRdFEehkV1wVD/YFa3NdV2zb9memaUKSJEzLLr9RvMtZ0iz6//Auen5NZ/ADPUqe7N+duZ4AAAAASUVORK5CYIILAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA==</imageBackground>
    </resource>
    <resource name="buttonObsidian_Pressed" backColor="Transparent" borderColor="Transparent"
              imageBackgroundStyle="Stretched" backGradientStyle="None" backHatchStyle="None"
              imageBackgroundStretchMargins="4, 4, 5, 4">
      <imageBackground>AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAAegEAAAKJUE5HDQoaCgAAAA1JSERSAAAAFgAAABQIBgAAAIl8zTAAAAABc1JHQgCuzhzpAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAACXBIWXMAAAsQAAALEAGtI711AAAA40lEQVQ4T7WVMQuDMBBG7R9s+zPd1U3BRRAlRRBBEERwlBCnKrTlay6tKXSrvQhvvMcRzMsBgOfkC8PQ05w1F81Dc9PcdyL03Imcm/Tati2klJjneRfTNKFpGmipIrmXJAmEEBiGgYWiKBDHMWhjVFWFuq5ZIBc5jbgsS1asOM9zcGLFWZaBE/cb+74PTuzGQRCAEyumf5kT92fMdTk2j9246zpwYsRRFJlGjOPIQt/3ryudpqmp0t6qfc9RK8hJrThqJMmVUliWBeu6/gzN0hm/O34i8SanSFPo/+ETenqaXPAEvtFyAQWxeMIAAAAASUVORK5CYIILAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA==</imageBackground>
    </resource>
    <resource name="explorerBarGroupHeaderObsidian_Active" backColor="Transparent" backGradientStyle="None"
              backHatchStyle="None" />
    <resource name="explorerBarGroupHeaderObsidian_HotTracked" backColor="Transparent" borderAlpha="Transparent"
              backGradientStyle="None" backHatchStyle="None">
      <imageBackground>AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAAewEAAAKJUE5HDQoaCgAAAA1JSERSAAAAJAAAABkIBgAAAFnkjOsAAAABc1JHQgCuzhzpAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAACXBIWXMAAAsQAAALEAGtI711AAAA5ElEQVRIS+3VqwqEUBSF4ePLaZ3HmDTNarMZbd5Qm8WpZhFBBEEEQXyXPS7YTDnBuIrCH9ZM+dgIOiLSep73chzHMJ/LYbqu+xoFyXme1K6jXBRpAWowjuOgpqAGoBpj33dqCqoBSjC2baOmoASgGGNdV2oKigGKMJZloaagCKAQY55nagoKAQowpmmipqAAIB9jHEdqCvIB+riuK8MwUIMBFoDeGH3fU1PQGyCDkaYpNQWZPyjLMmFmgfI8F2YWqCgKYWaByrIUZhaoqiph9oDurv9c6LnQ3QXu/rfeIfzADt/VH1OoPeSVGV52AAAAAElFTkSuQmCCCwAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA</imageBackground>
    </resource>
    <resource name="explorerBarGroupHeaderObsidian_Normal" backColor="Transparent" foreColor="White"
              borderColor="Transparent" imageBackgroundStyle="Stretched" backGradientStyle="None" backHatchStyle="None"
              imageBackgroundStretchMargins="5, 0, 5, 0">
      <imageBackground>AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAAdgEAAAKJUE5HDQoaCgAAAA1JSERSAAAAJAAAABkIBgAAAFnkjOsAAAABc1JHQgCuzhzpAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAACXBIWXMAAAsQAAALEAGtI711AAAA30lEQVRIS+3ToQqEQBSF4dnHEkEEUes+hslmtQmGCQYtChYtWtxg0Ke7y4GLZcJuOwaFPxzTxwzzEpEtTdO3ucF3nufHAJQkiRzHQQ0GWABaMfZ9p6agFaAJY9s2agqaABowlmWhpqABoBZjnmdqCmoBshjjOFJTkAWowuj7npqCKoBKjK7rqCmoBKjAaJqGmoIKgHIMay01BeUAZRh1XVNTUAaQwfA8j5qCzAXyfV+YOaAgCISZAwrDUJg5oCiKhJkDiuNYmDkg/GCHF3+9MjbmOaF/buC5sl+ndMsT+gKH6M6hN60VEAAAAABJRU5ErkJgggsAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=</imageBackground>
    </resource>
    <resource name="headerObsidian_Normal" foreColor="White" imageBackgroundStyle="Stretched" fontBold="True"
              imageBackgroundStretchMargins="1, 2, 2, 0">
      <imageBackground>AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAAGQEAAAKJUE5HDQoaCgAAAA1JSERSAAAAIgAAABkIBgAAAFT6/KwAAAABc1JHQgCuzhzpAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAACXBIWXMAAAsQAAALEAGtI711AAAAgklEQVRIS+3TIQqEIRQE4NlzCSL8/N7EywgGk8FisZgsgp5utm/ZOsEHXx9meJ8QAqFwe28qwDmHCrDWogLMOakAYwwqQO+dCtBaowLUWqkApRQqQM6ZCpBSogLEGKkAxhgqgLWWCuCcowI8z0MFeN+XCuC9p4Ib5HeF28ht5N9nfgHxx3vlgsb/sgAAAABJRU5ErkJgggsAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=</imageBackground>
    </resource>
    <resource name="progressBarFillObsidian_Normal" foreColor="White" imageBackgroundStyle="Stretched">
      <imageBackground>AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAAFwEAAAKJUE5HDQoaCgAAAA1JSERSAAAAIgAAABkIBgAAAFT6/KwAAAABc1JHQgCuzhzpAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAACXBIWXMAAAsQAAALEAGtI711AAAAgElEQVRIS+3ToQpEIRQE0NnPEkEeiH6bwWCxGEwWk8Xg381j65atE7xw+jDD/ZxzCIX7BlGAvTcVYK1FBZhzUgHGGFSA3jsVoLVGBai1UgFKKVSAnDMVIKVEBTDGUAGstVQA5xwV4HkeKoD3ngoQQqACxBip4Ab5XeE2chv595kvtj5EsPNEVfUAAAAASUVORK5CYIILAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=</imageBackground>
    </resource>
    <resource name="scrollBarThumbHorizontalObsidian_HotTracked" imageBackgroundStyle="Stretched"
              imageBackgroundStretchMargins="5, 3, 7, 4">
      <imageBackground>AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAAqQEAAAKJUE5HDQoaCgAAAA1JSERSAAAAFgAAABQIBgAAAIl8zTAAAAABc1JHQgCuzhzpAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAACXBIWXMAAAsQAAALEAGtI711AAABEklEQVQ4T7WVQY9DUBSF3/z/v6MbtFQ3FkgTKwu0kaggw4IIFmd63mRkklmZ3r7kS2zuh+ve4wOAessxDEORMAy74/GI5zUOh8NuWEvHj09LXdfF+XzG4/HAuq7Pl9h3WFOWpXbQRaeKogie52GaJizL8hJ0nE4n0Kls28b9fsc4jiJkWQY6FfvZti26rhOhaRr9fbS4rmtRNnFRFJBEizle7IskdGrx5XIRZRNz/iTZxL7vQ5JNfL1eIckmTpIEkmgxRyPPc719EqRp+r0gpmnqp62qSoQ4jkGnCoIAjDyudd/3L8F1potOHZuO44CwJcMwYJ7nXbDmdrvBsizt0bH5K+g/ebf/hDxr/gQ9f03v4AtHiK85UrGUJQAAAABJRU5ErkJgggsAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=</imageBackground>
    </resource>
    <resource name="scrollBarThumbHorizontalObsidian_Normal" imageBackgroundStyle="Stretched"
              imageBackgroundStretchMargins="7, 2, 7, 3">
      <imageBackground>AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAAngEAAAKJUE5HDQoaCgAAAA1JSERSAAAAFgAAABQIBgAAAIl8zTAAAAABc1JHQgCuzhzpAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAACXBIWXMAAAsQAAALEAGtI711AAABB0lEQVQ4T7WVQYtFUBiGzf//O2y4DPZuFqJkQUIWKHKJxTveU9fMNCtzv6ueYvE95Tjn8QFAe8ul67pGgiD4NE0Txz0Mw7gMZ+l4+pTUdd2H53lomgb7vh8vce3iTF3XoIMuOrUkSeD7PtZ1VdJXoMNxHNCp2baNsiyxLIsIeZ6DTo3rOQwDxnEUoe979X2UmA+SnOK2bSHJKa6qCpIoMfdtGIai0KnE9/tdlFMcRREkOcVpmkISJeZCF0Uhyq9dwU5IwFOsxLfbDVmWoes6EeI4Bp0qQgwHT940TS9BBzuhIvTM5pE7MCDzPGPbtktwhrOWZX1n80foHcb6P5HnzJ/Q89f0Dr4AOsDEpS005nsAAAAASUVORK5CYIILAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA==</imageBackground>
    </resource>
    <resource name="scrollBarThumbHorizontalObsidian_Pressed" imageBackgroundStyle="Stretched"
              imageBackgroundStretchMargins="5, 3, 7, 4">
      <imageBackground>AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAAqQEAAAKJUE5HDQoaCgAAAA1JSERSAAAAFgAAABQIBgAAAIl8zTAAAAABc1JHQgCuzhzpAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAACXBIWXMAAAsQAAALEAGtI711AAABEklEQVQ4T7WVQY9DUBSF3/z/v6MbtFQ3FkgTKwu0kaggw4IIFmd63mRkklmZ3r7kS2zuh+ve4wOAessxDEORMAy74/GI5zUOh8NuWEvHj09LXdfF+XzG4/HAuq7Pl9h3WFOWpXbQRaeKogie52GaJizL8hJ0nE4n0Kls28b9fsc4jiJkWQY6FfvZti26rhOhaRr9fbS4rmtRNnFRFJBEizle7IskdGrx5XIRZRNz/iTZxL7vQ5JNfL1eIckmTpIEkmgxRyPPc719EqRp+r0gpmnqp62qSoQ4jkGnCoIAjDyudd/3L8F1potOHZuO44CwJcMwYJ7nXbDmdrvBsizt0bH5K+g/ebf/hDxr/gQ9f03v4AtHiK85UrGUJQAAAABJRU5ErkJgggsAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=</imageBackground>
    </resource>
    <resource name="scrollBarThumbVerticalObsidian_HotTracked" imageBackgroundStyle="Stretched"
              imageBackgroundStretchMargins="7, 7, 7, 7">
      <imageBackground>AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAAxwEAAAKJUE5HDQoaCgAAAA1JSERSAAAAFAAAABYIBgAAAMBBvAYAAAABc1JHQgCuzhzpAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAACXBIWXMAAAsQAAALEAGtI711AAABMElEQVQ4T+2VP4uDQBDF1846pV/Jr6uN+DeNjRgRQVQiKgYRRJAEQZt3zoJC8O5C5LrLwgi7OD/XYeY9AQBTVZXRkiQJXdexeZ75/rslCMJ2LIoiO51O7Ha78UNZlhkjoKIozLIsOI6DJElwvV6RpiniOEYYhnBdF0EQ8H1RFGjbFn3fo6oq2LYNyiUGsfjD87z+fD5jHEc0TYM8z18Ch2HANE08xzRNEGMD6rqOuq75C+8CKacsSxBjAy415F86Cnw8HiDGE5BgR4GU9wGqvH6fGv46euukrKX6722zSM/ftg0BacCP9uFOHEh6SIKOAkmQn+SLxNEwDH7Ld/Xwfr/vBXa1AJLyKIqQZdlLxV68h9sB3WxnAQSk8H0fmqaRP/wY1MBr0F9dLhfuJ6unfAFiO8pPdzuykgAAAABJRU5ErkJgggsAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=</imageBackground>
    </resource>
    <resource name="scrollBarThumbVerticalObsidian_Normal" imageBackgroundStyle="Stretched"
              imageBackgroundStretchMargins="7, 7, 7, 7">
      <imageBackground>AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAAwQEAAAKJUE5HDQoaCgAAAA1JSERSAAAAFAAAABYIBgAAAMBBvAYAAAABc1JHQgCuzhzpAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAACXBIWXMAAAsQAAALEAGtI711AAABKklEQVQ4T+2VTWqEQBCF26V3cOdxvK5uBOPf2rXiRkXUQdyIGlSEF1+DQ8xAhpHsMg0tVNv1dVltvVIACMuyBIeu66jrWszzLO1jcI+iKKc1GqqqCk3TRJqm8qVhGEJws2mawvO8zyAIkOc5brcbmqZBVVUoigJJkiDLMml3XYdhGDBNEw+H7/ugLxlkyUcURR9hGGLbNvR9j7ZtnwKXZdldIX1c1wUZd6Bt2zIqjleB9GHkZNyBew7lSVeB67qCjBNQ0i5GSL83UCb0ncPfS++olCNV//232aXnb38bAlngV2uZF3S6FEoPJegqkCJ8ki+K4z7Ak17VQ/o8COzRAnYpx94fpLQ/awHjOKIsSziO89gCCOSM41huYD6+T+b45xptfhUDOPwpsF8/B/OSrrjKcQAAAABJRU5ErkJgggsAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=</imageBackground>
    </resource>
    <resource name="scrollBarThumbVerticalObsidian_Pressed" imageBackgroundStyle="Stretched"
              imageBackgroundStretchMargins="7, 7, 7, 7">
      <imageBackground>AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAAxwEAAAKJUE5HDQoaCgAAAA1JSERSAAAAFAAAABYIBgAAAMBBvAYAAAABc1JHQgCuzhzpAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAACXBIWXMAAAsQAAALEAGtI711AAABMElEQVQ4T+2VP4uDQBDF1846pV/Jr6uN+DeNjRgRQVQiKgYRRJAEQZt3zoJC8O5C5LrLwgi7OD/XYeY9AQBTVZXRkiQJXdexeZ75/rslCMJ2LIoiO51O7Ha78UNZlhkjoKIozLIsOI6DJElwvV6RpiniOEYYhnBdF0EQ8H1RFGjbFn3fo6oq2LYNyiUGsfjD87z+fD5jHEc0TYM8z18Ch2HANE08xzRNEGMD6rqOuq75C+8CKacsSxBjAy415F86Cnw8HiDGE5BgR4GU9wGqvH6fGv46euukrKX6722zSM/ftg0BacCP9uFOHEh6SIKOAkmQn+SLxNEwDH7Ld/Xwfr/vBXa1AJLyKIqQZdlLxV68h9sB3WxnAQSk8H0fmqaRP/wY1MBr0F9dLhfuJ6unfAFiO8pPdzuykgAAAABJRU5ErkJgggsAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=</imageBackground>
    </resource>
    <resource name="scrollBarTrackHorizontalObsidian_Normal" imageBackgroundStyle="Stretched"
              imageBackgroundStretchMargins="7, 0, 8, 0">
      <imageBackground>AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAAiAIAAAKJUE5HDQoaCgAAAA1JSERSAAAAJAAAAA8IBgAAAIxrbW0AAAABc1JHQgCuzhzpAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAACXBIWXMAAAsQAAALEAGtI711AAAB8UlEQVRIS8WVVa7DQAxF/Uoflbr/NZWZmZkZ3Rw/dQdTNZIVNckkx/deT//UOw6Hg6zXa3m9XhIKhSQYDEogEBC/3y8+n09cH94n5fl8Wj0eD+F3JBKRcDgsst/vNZ/Pa7Va1V6vp5PJRFerle52Oz0ej3o+n53X6XRSvrvZbHQ2m+lgMNBms4kwKo1GQzOZjNZqNR0Oh7pYLAyGRdfrVb0OnNf9ftfL5WIAND8ajQyo1WqpFAoFzWazChg3lsul0bOAhZ6s6lnptHgnzeKAFxVzBZhisaiSTqdNoXq9/hOFABqPx6aQAaVSKQUKy/AST/EWOVHpdrs5L9QhEkQDR3AGh3BLksmkAkWo+/2+TqdT8xXbWASU62JQaJjGySxC4BDDJYlEQoH61ZTN53MDwqFcLqcSj8cNqFwua7fbNT+hhh6VCJ7rQp3tdmtO4AjbDYIwXAaESgB1Oh0LNtQ8zCKgXBfZ+djFhAFUqVT+gWKxmAJVKpVs9JAPasLGBADluoChYRrHEYRAEKbdMgQUCSfp0PLQRyWgXBcwxILGEQAhEIRpF2Y/Go2aXAQLWh5CSrYAwFwX7wWGcSe3TBgcQAl2AAQdF7gJFFsAYGTqG8X7gWFDJNCMPFbyT2sZ4SKUnHkIKOz7VgHTbrctJpwJOscbkpGKu7plDhQAAAAASUVORK5CYIILAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA==</imageBackground>
    </resource>
    <resource name="scrollBarTrackVerticalObsidian_Normal" backColor="Transparent" imageBackgroundStyle="Stretched"
              backGradientStyle="None" backHatchStyle="None" imageBackgroundStretchMargins="0, 12, 0, 13">
      <imageBackground>AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAAYgIAAAKJUE5HDQoaCgAAAA1JSERSAAAADwAAACQIBgAAAFa9YL8AAAABc1JHQgCuzhzpAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAACXBIWXMAAAsQAAALEAGtI711AAABy0lEQVRIS+2WN47DQAxFuZVL977/aZxzzjnnnLh6XIwhC9tst4UFECPTM1/kjPWfv9S7DoeDTKdTOZ1OwuWl3sKfC4VCEolEJBwOi+z3ey0WixalUsnGQqGg+Xxec7mcRTab1Uwmo+l0WlOplCYSCV2v1yr9fl8bjYa2Wi3tdDrabrftvtlsWr5er1tUq1WtVComjnCtVvtZPBgMdDwe62QyseB+OBxa8H2v19Nut2vCCCJSLpdVmDybzXS1WlkpjIvFQufzueWd2Gg0socgQlVUI0xkEb17G2fjdru1HLFcLt+EqIb2aE2YsNvt9Hw+6+VysfF4PJoI+c1m8yZCJbSBgDCBybfbTR+Ph42IeMf2EnGVUIV3pK/y7aiYeL/f9fl82ni9Xq0C8rTiKmA/2AfX+2fxZ8M+PxLv1fy8GF39J2aAAf7Jw3BGTA7HdM7p7Ddofs49oQjmLxw8Athv0LP9lgsccE5QhG+DHiGBIhOxWP+CIC1ADk91zBLwQRIR+ERg7EFGuVLBDIQEdsJClOjBT8TfcMsi6AhmgZ2ds2MvaoQf8oDeAR7IA3iC9vj7YL2CTKAN+ZPJpNE/Ho9rLBaziEaj9hkx4Mf1DYgT4re6ZypXAAAAAElFTkSuQmCCCwAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA</imageBackground>
    </resource>
    <resource name="sharedSilverObsidian" backColor="Transparent" foreColor="30, 30, 30"
              imageBackgroundStyle="Stretched" fontBold="True" backGradientStyle="None"
              imageBackgroundStretchMargins="3, 3, 3, 3">
      <imageBackground>AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAA5wAAAAKJUE5HDQoaCgAAAA1JSERSAAAADAAAABYIAgAAAHta6k0AAAABc1JHQgCuzhzpAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAACXBIWXMAAAsQAAALEAGtI711AAAAUElEQVQ4T43SsQ3AIAxE0Z8RM5f3yhzpQgEiRSQKRGAE/hvgLPt8RARbXaAJVIFXIAsUwSWJaZlb4BFIgttOHLzyCa5g8QSNIfALTIFT4BIWzS6twcrqhOMAAAAASUVORK5CYIILAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=</imageBackground>
    </resource>
    <resource name="tabItemHorizontalBottomObsidian_Normal" foreColor="White" borderColor="Transparent"
              imageBackgroundStyle="Stretched" fontBold="True" imageBackgroundStretchMargins="8, 0, 9, 0">
      <imageBackground>AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAAXgEAAAKJUE5HDQoaCgAAAA1JSERSAAAAJAAAABgIBgAAAJK4X04AAAABc1JHQgCuzhzpAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAACXBIWXMAAAsQAAALEAGtI711AAAAx0lEQVRIS+3SvQqDQBAE4Mn7P5Wi+IOihQo2x2EnYiUiqDhhD5JAGqvELVz4RBtvmL2H53mEppFAmkBTGLetO9DJFbkbOrsid0OnDfm+T00QBAE1QRiG1ARRFFETxHFMTZAkCTVBmqbUBFmWURPkeU4tqqoi6rpmURQqGGOIrutYlqUK4zgS67qybVs2TXMpaUcG8pjnmdbay8iWtm37BJI3aWoYBvZ9/1eypn3fXZh3Q6+P4zhcsGVZXGvTNP2E/FvOkLO+5wmrafVcld1V/gAAAABJRU5ErkJgggs=</imageBackground>
    </resource>
    <resource name="tabItemHorizontalBottomObsidian_Selected" imageBackgroundStyle="Stretched"
              imageBackgroundStretchMargins="7, 0, 8, 0">
      <imageBackground>AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAAcgEAAAKJUE5HDQoaCgAAAA1JSERSAAAAJAAAABgIBgAAAJK4X04AAAABc1JHQgCuzhzpAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAACXBIWXMAAAsQAAALEAGtI711AAAA20lEQVRIS+3SKw6EMBgE4NkzkSAwGAwCgcEgUHgSDJIr4FBwDAwWroDEYHkEgSOzKQmsRO3uL2jyNa1pJ9O+NE0jJA0VSBJICnO81hPo5os8Dd19kaeh24Z0XackMAyDksA0TUoCy7IoCWzbpiRwHIeSwHVdSgLP8ygJfN+nFFEUEXEcMwgCEbIsI8qyZBiGIrRtS8zzzDRNmSTJX6l21ICa+r5nnud/UxQF13X9BFKrcRxZ1zWrqvqppmm4bdsR5mro3Oz7zmmaOAzD0VrXdV+hzlZ3LMtyBTkXb13zezIPspyEAAAAAElFTkSuQmCCCwAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA</imageBackground>
    </resource>
    <resource name="tabItemHorizontalTopObsidian_Normal" backColor="White" foreColor="White" borderColor="Transparent"
              imageBackgroundStyle="Stretched" fontBold="True" backGradientStyle="None" backHatchStyle="None"
              imageBackgroundStretchMargins="7, 0, 7, 0">
      <imageBackground>AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAAYAEAAAKJUE5HDQoaCgAAAA1JSERSAAAAJAAAABgIBgAAAJK4X04AAAABc1JHQgCuzhzpAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAACXBIWXMAAAsQAAALEAGtI711AAAAyUlEQVRIS+3STQtEUBgF4HP9/z9F5CNigyVZKNkolPJxZu6tKTMbi6mZd+HUU3Kp00HxGZxyHAc0nY+j82NfXSulzPuWZRlv0YV09n3nPM8cx/Gnpmnitm2vGtQrmBt937Prur9ZlsWUMoXatmVd13/VNA3XdSWGYWBRFCLoYVBVFbMsE6EsSyLPc6ZpKgaSJKEkiOOYkiCKIkqCMAwpCYIgoCTwfZ+SwPM8SgLXdSkJHMehJLBtm5Lcha6+xr3QvdDVAlfn4v6hB3+Z/EbZ8KNKAAAAAElFTkSuQmCCCwAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA</imageBackground>
    </resource>
    <resource name="tabItemHorizontalTopObsidian_Selected" imageBackgroundStyle="Stretched">
      <imageBackground>AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAAegEAAAKJUE5HDQoaCgAAAA1JSERSAAAAJAAAABgIBgAAAJK4X04AAAABc1JHQgCuzhzpAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAACXBIWXMAAAsQAAALEAGtI711AAAA40lEQVRIS+3SIcqEUBQF4KOiGxIMFovFYLBYDCZXYHEjgskNuACLWzALFqtZ0CDomXkDw0yz/Pxzgxc+eHDhcTjvaXwOvmbfdyjneeI4ju/Vn50Nw4Cu6zBNE5ZlQdO0z90qkJpnCE7TxGEY/tU4jlzX9R2DUKdt29h1Hdu2/Zl5nl+hXoGapmFVVT9V1zWXZSH6vmdRFCKoYlCWJbMsE0EVgzzPmaapGEiShJIgjmNKgiiKKAnCMKQkCIKAksD3fUoCz/MoCVzXpSRwHIeSwLZtSnIHunqNu6G7oasGrvbi/tAD8ZOANiUt158AAAAASUVORK5CYIILAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA==</imageBackground>
    </resource>
    <resource name="tabItemVerticalLeftObsidian_Normal" borderColor="Transparent" imageBackgroundStyle="Stretched"
              imageBackgroundStretchMargins="8, 6, 0, 6">
      <imageBackground>AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAAdgEAAAKJUE5HDQoaCgAAAA1JSERSAAAAGAAAACQIBgAAAJPP+i4AAAABc1JHQgCuzhzpAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAACXBIWXMAAAsQAAALEAGtI711AAAA30lEQVRIS+1XywqDQAxM//+rFMUHip70qHgQxIuigviabqALPRR7aHNLYMk+2J0QEnbmAWP0suM4qO97GseR1nWl67qIj63n+fva7tv7Hz0DsJkH0TQNiqJAnufIsgxpmiJJEsRxjCiKEIYhgiCA7/vwPA+u68JxnNvBEcFEjq7rUNe1DMA8z3IA53limiY5gH3fZQG2bVOA+zLVFH3tZE2Rpuj3/0CrSKtIqwikffC1D8R5kTiAOHVkdr0sixw3ZQAjJGCEhxx9txqhbVsZfWBVDvthGFBVFcqy/IvCeQLVJlftYP3HxgAAAABJRU5ErkJgggsAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=</imageBackground>
    </resource>
    <resource name="tabItemVerticalLeftObsidian_Selected" foreColor="White" imageBackgroundStyle="Stretched"
              fontBold="True" imageBackgroundStretchMargins="8, 5, 0, 6">
      <imageBackground>AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAAoAEAAAKJUE5HDQoaCgAAAA1JSERSAAAAGAAAACQIBgAAAJPP+i4AAAABc1JHQgCuzhzpAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAACXBIWXMAAAsQAAALEAGtI711AAABCUlEQVRIS+2XO4qFMBSGc9ckWNjY2FhY2NhYWLkHG5chWLkBF6CFW9BWsLHUSgVRfP/35jKBKYY7xZhiIAdCHpB85OQk+c8DLyNfNo4jSdOUFEVBmqYhx3GQfd/fhba/99nYeZ5s+s81BVBr2xZRFMHzPLiuC8dxYNs2LMuCaZowDAO6rkPTNKiqCkVRIMsyJEn6WAhdfJomJEmCMAzvB1zXhaqq+AGWZUFZlvwAr4PlC+j7ni+g6zoB+HwPhIt+fSqEi4SL/v7hiCgSUSSiCOT/34NhGPiqCu7Ca11Xvjug6rqua37alAK2bUOWZXzkO0tA5nlGHMf35wcMwOo8zxEEAXzfvyXDeQJPYfGL6XDnHQAAAABJRU5ErkJgggsAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=</imageBackground>
    </resource>
    <resource name="tabItemVerticalRightObsidian_Normal" foreColor="White" borderColor="Transparent"
              imageBackgroundStyle="Stretched" fontBold="True" imageBackgroundStretchMargins="0, 8, 9, 7">
      <imageBackground>AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAAiQEAAAKJUE5HDQoaCgAAAA1JSERSAAAAGAAAACQIBgAAAJPP+i4AAAABc1JHQgCuzhzpAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAACXBIWXMAAAsQAAALEAGtI711AAAA8klEQVRIS+2XTQuEIBCGtVN0Cfr/f6Yo+qCoS0GXiG4RnSqCit7FQNhlY2VhB/agICqCzzg64yt3XRdMUTjnzDAM9tyKvhxblsVM02S2bTPHcV5XEwBV9TwPvu8jCAKEYYgoihDHMZIkQZqmyLIMeZ6jKAo0TYN93yELUy0u5r8BVFWFrutwHMfFIAG0bYtxHGkBfd9j2za6HQjAuq60gHmeaQHTNGnAe6CJOBDXVByydtFtLtIuUqZr7SLtonsB8O2brHPRR12kA+2/Ao1ctpALL1LpOAwDzvOkE17CehL5Xtc1lmX5/QekLMvr4yEtl4QHqeEYqEzRC5EAAAAASUVORK5CYIILAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA==</imageBackground>
    </resource>
    <resource name="tabItemVerticalRightObsidian_Selected" foreColor="White" imageBackgroundStyle="Stretched"
              fontBold="True" imageBackgroundStretchMargins="0, 7, 8, 7">
      <imageBackground>AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAAqAEAAAKJUE5HDQoaCgAAAA1JSERSAAAAGAAAACQIBgAAAJPP+i4AAAABc1JHQgCuzhzpAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAACXBIWXMAAAsQAAALEAGtI711AAABEUlEQVRIS+2XPYqEMBTHM6hn8ALeQLGwsbGxsLCxsbDyBDaWXsHOSo9hY+sZBBFsbP3Awk7+s1mYgWGHlYF9sEUCgXyQ9yMveS//3HRdB7sokiQxWZaZoijPyvuPMU3TmKqqzDAMZlnWqzUOuKqmaeJrIWzbhuM4cF0XnufB930EQYAwDBFFEeI4Rp7n2Pcdj8KujPP5TwBpmqIsSxzH8c0gARRFgbZtaQF1XWPbNrodcMA0TbSAYRhoAV3XCcDPQONxwK8pP2Thore5SLjoMl0LFwkXvRcAn77JIhf9qotEoP2vQOv7nlZVkAuvZVnodtA0Dc7zpAPM80yjrrMswziOf/8BSZIEVVVhXdencd64A7n7gbxLXFzSAAAAAElFTkSuQmCCCwAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA</imageBackground>
    </resource>
    <resource name="ultraProgressBarObsidian_Normal" borderColor="Silver" imageBackgroundStyle="Stretched">
      <imageBackground>AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAADQEAAAKJUE5HDQoaCgAAAA1JSERSAAAAIgAAABkIBgAAAFT6/KwAAAABc1JHQgCuzhzpAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAACXBIWXMAAAsQAAALEAGtI711AAAAdklEQVRIS+3TuQ0AIQxE0dn+a+MqARCXgBpmRbrJphNg6eVftvzsvQmFOSEKsNaiAsw5qQBjDCpA750K0FqjAtRaqQClFCpAzpkKkFKiAsQYqQDGGCqAtZYK4JyjAp0Q7z0VQCHiNCCEQAU35HuFu5G7kb/PfAHCt1sLAZE0cwAAAABJRU5ErkJgggsAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=</imageBackground>
    </resource>
  </resources>
</styleLibrary>