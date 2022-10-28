<!DOCTYPE html>
<html>
<head>
  <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
  <meta name="viewport" content="initial-scale=1.0, user-scalable=no" />
  <style type="text/css">
    body, html {width: 100%;height: 100%;margin:0;font-family:"微软雅黑";}
    #allmap{width:100%;height:100%;}
    p{margin-left:5px; font-size:14px;}
  </style>
  <script type="text/javascript" src="http://api.map.baidu.com/api?v=2.0&ak=5H81a8zEwctwf081w60uwCbt0ZktgwL2"></script>
  <title>map</title>
</head>
<body>
  <div id="allmap"></div>
<div id="lng" style="display:none"></div>
<div id="lat" style="display:none"></div>
</body>
</html>
<script type="text/javascript">

	var map = new BMap.Map("allmap");
	map.centerAndZoom(new BMap.Point(116.404, 39.915), 4);

    map.addControl(new BMap.ScaleControl());// 添加相关控件
    map.addControl(new BMap.OverviewMapControl());// 添加相关控件

    var ctrl_nav = new BMap.NavigationControl({ anchor: BMAP_ANCHOR_TOP_LEFT, type: BMAP_NAVIGATION_CONTROL_LARGE }); 

    map.addControl(ctrl_nav) ;// 添加相关控件
    map.enableDragging(); 
    map.enableScrollWheelZoom()
    map.enableDoubleClickZoom(); 
    map.enableKeyboard(); 
  map.enableContinuousZoom(); 
    map.enableInertialDragging(); 
  var geolocationControl = new BMap.GeolocationControl();
  geolocationControl.addEventListener("locationSuccess", function(e){
    // 定位成功事件
    var address = '';
    address += e.addressComponent.province;
    address += e.addressComponent.city;
    address += e.addressComponent.district;
    address += e.addressComponent.street;
    address += e.addressComponent.streetNumber;
    alert("当前定位地址为：" + address);
  });
  geolocationControl.addEventListener("locationError",function(e){
    // 定位失败事件
    alert(e.message);
  });
  map.addControl(geolocationControl);

function openGetDistance() {  
     var myDis=new BMapLib.DistanceTool(map);//mapΪɏæґ¾­³õʼ»¯ºõĵ؍¼ʵÀý  
     myDis.open();  
    }


    var marker_num = 0;

    var isAddListen = -1;
function ClearAllMarkers() {

        map.clearOverlays();

        marker_num = 0;

        isAddListen = -1;

    }

    function CloseListener() {

        map.removeEventListener("rightclick", putmarker);

    }
function FindPosition(CurLng, CurLat) {


        var point = new BMap.Point(CurLng, CurLat);

        map.centerAndZoom(point, 20);

    }

    var Lng = 116.380960

    var Lat = 39.913280

    function GetTestGPS(CurLng, CurLat) {


        var point = new BMap.Point(CurLng, CurLat);

        map.centerAndZoom(point, 20);

        window.external.LocateInfo(text);

        return Lng;

    }

    function GetTest2GPS() {

        var text = '{"Point":[{"x":"116.380960","y":"39.913280"},{"x":"116.380961","y":"39.913281"},{"x":"116.380962","y":"39.913282"},{"x":"116.380963","y":"39.913283"}]}'

        window.external.LocateInfo(text);

        return text;

    }

	function myTimer(JinDu, WeiDu, str)	
{	
    var BaiDuPoint = new BMap.Point(JinDu, WeiDu);   
    map.centerAndZoom(BaiDuPoint, 17);	
    var marker = new BMap.Marker(BaiDuPoint);		
    map.addOverlay(marker);		
    //map.openInfoWindow(infoWindow, BaiDuPoint); 
    //map.setCenter(BaiDuPoint); //Ҕµ±ǰµėø±굣Ϊ֐Єϔʾ
	var label = new BMap.Label(str,{offset:new BMap.Size(20,-10)});
	marker.setLabel(label);
}
	function addmarkerinfo(jingdu,weidu,wenzi)
{
	var point = new BMap.Point(jingdu , weidu);
	var marker = new BMap.Marker(point);  // 创建标注
	var content = wenzi;
	map.addOverlay(marker);               // 将标注添加到地图中
	addClickHandler(content,marker);  

}


function addClickHandler(content,marker){
		marker.addEventListener("click",function(e){
			openInfo(content,e)}
		);
	}
	function openInfo(content,e){
		var p = e.target;
		var opts = {
				width : 250,     // 信息窗口宽度
				height: 100,     // 信息窗口高度
				title : "信息窗口" , // 信息窗口标题
				enableMessage:true//设置允许信息窗发送短息
			   };
		var point = new BMap.Point(p.getPosition().lng, p.getPosition().lat);
		var infoWindow = new BMap.InfoWindow(content,opts);  // 创建信息窗口对象 
		map.openInfoWindow(infoWindow,point); //开启信息窗口
	}
function getlocation()
{var geolocation = new BMap.Geolocation();
	geolocation.getCurrentPosition(function(r){
		if(this.getStatus() == BMAP_STATUS_SUCCESS){
			//var pt = new BMap.Point(116.417, 39.909);
			var myIcon = new BMap.Icon("http://lbsyun.baidu.com/jsdemo/img/fox.gif", new BMap.Size(300,157));
			var markerspe = new BMap.Marker(r.point,{icon:myIcon});  // 创建标注
			map.addOverlay(markerspe);              // 将标注添加到地图中
			var mk = new BMap.Marker(r.point);
			map.addOverlay(mk);
			mk.setAnimation(BMAP_ANIMATION_BOUNCE);
			map.panTo(r.point);
			alert('您的位置：'+r.point.lng+','+r.point.lat);
            document.getElementById("lng").innerText = r.point.lng;
            document.getElementById("lat").innerText = r.point.lat;
			lnginfo=r.point.lng.toString();
			latinfo=r.point.lat.toString();
			window.external.Lnginfo(lnginfo);
			window.external.Latinfo(latinfo);
		}
		else {
			alert('failed'+this.getStatus());
		}        
	},{enableHighAccuracy: true})

	}
function findemergency(x1,y1,x2,y2){
	var p1 = new BMap.Point(x1,y1);
	var p2 = new BMap.Point(x2,y2);
	var walking = new BMap.WalkingRoute(map, {renderOptions: {map: map, panel: "r-result", autoViewport: true}});
    walking.search(p1, p2);
}
</script>
