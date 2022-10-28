import urllib.request
import turtle
import matplotlib.pyplot as plt
from bs4 import BeautifulSoup
import xlwt
#from pymssql import *
def readhtml(url):
    try:
        head={}
        data={}
        head['User-Agent']="Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/45.0.2454.101 Safari/537.36"
        req=urllib.request.Request(url,data,head)
        response=urllib.request.urlopen(req)
        html=response.read()
        html=html.decode('utf-8')
        return html
    except:
        return ""
def analyze(html,alist,datalinks):
    soup=BeautifulSoup(html,'html.parser')
    datalinks=soup.find_all('tr')
    for i in datalinks:
        x=i.find_all('td')
        if len(x)==0:
            continue
        blist=[]
        for y in x:
            blist.append(y.string)
        alist.append(blist)
def datacollect(alist,zlist,ilist):
    for i in range(30):
        x=alist[i]
        ilist.append(int(x[4]))
        zlist.append(float(x[0]))
def filedeal(alist):
    g=["震级大小","时间","纬度","经度","震源深度","地点"]
    datas=[]
    datas.append(g)
    for i in range(len(alist)):
       datas.append(alist[i])#二维数组
    file_path = r'earthquake.xls'
    wb = xlwt.Workbook()
    sheet = wb.add_sheet('test')#sheet的名称为test
    #单元格的格式
    style = 'pattern: pattern solid, fore_colour yellow; '#背景颜色为黄色
    style += 'font: bold on; '#粗体字
    style += 'align: horz centre, vert center; '#居中
    header_style = xlwt.easyxf(style)     
    row_count = len(datas)
    col_count = len(datas[0])
    for row in range(0, row_count): 
        col_count = len(datas[row]) 
        for col in range(0, col_count):
            if row == 0:#设置表头单元格的格式
                sheet.write(row, col, datas[row][col], header_style)
            else:
                sheet.write(row, col, datas[row][col])
    wb.save(file_path)
def collecttime(alist,plist,olist):
    for i in range(30):
        x=alist[i]
        plist.append(str(x[1]))
    for y in plist:
        i=y.replace(' ','')
        g=i.replace('-','')
        v=g.replace(':','')
        w=int(v)
        w=w+1
        e=str(w)
        olist.append(e)
def filetohtml(alist,olist):
    txt='<table border="1">'
    txt=txt+'\n'+'<h1 style="text-align:center">'+"最新地震信息"+'</h1>'
    txt=txt+'\n'+'<tr>'
    g=["震级大小","时间","纬度","经度","震源深度","地点"]
    for f in range(6):
        txt=txt+'\n'+"<td>"+str(g[f])+"</td>"
    txt=txt+'\n'+'</tr>'
    for i in range(30):
        txt=txt+'\n'+'<tr>'
        x=alist[i]
        for f in range(6):
            if f<5:
                txt=txt+'\n'+"<td>"+str(x[f])+"</td>"
            else:
                txt=txt+'\n'+"<td>"+"<a href="'http://news.ceic.ac.cn/CD'+olist[i]+'.html'">"+str(x[f])+"</a>"+"</td>"
        txt=txt+'\n'+'</tr>'
    txt=txt+'\n'+'</table>'
    txt=txt+'\n'+'<h2 style="text-align:center">'+"地震网站链接"+'</h2>'
    txt=txt+'\n'+"<a href="'http://www.ceic.ac.cn/'">"+"中国地震台网"+"</a>"
    txt=txt+'\n'+"<a href="'https://earthquake.usgs.gov/earthquakes/map/'">美国地质勘探局</a>"
    txt=txt+'\n'+"<a href="'https://www.emsc-csem.org/#2'">欧洲地中海地震观测中心</a>"
    fileh=open(r'C:\Users\DELL\Desktop\earthquake.html','w')
    fileh.write(txt)
    fileh.close()
def draw(ilist,zlist):
    yValues = ilist
    zvalues=zlist
    t = turtle.Turtle()
    t.hideturtle()
    drawLine(t,-300,-250,300,-250)
    drawLine(t,-300,-250,-300,350)
    for i in range(29):
        drawLineWithDots(t,20 + (20 * i)-300,4 * yValues[i]-250,20 + (20 * (i+1))-300,4 * (yValues[i+1])-250,"blue")
    t.up()
    for i in range(30):
        t.goto(20 + (20 * i)-300,4 * yValues[i]-240)
        t.write(str(zvalues[i]),align="center")
    drawTickMarks(t,yValues)
    displayText(t,yValues)    
    ts = turtle.getscreen()
    ts.getcanvas().postscript(file="work.eps")
def drawLine(t,x1,y1,x2,y2,colorP="black"):
    t.up()
    t.goto(x1,y1)
    t.down()
    t.pencolor(colorP)
    t.goto(x2,y2)
def drawLineWithDots(t,x1,y1,x2,y2,colorP="black"):
    t.pencolor(colorP)
    t.up()
    t.goto(x1,y1)
    t.dot(5)
    t.down()
    t.goto(x2,y2)
    t.dot(5)
def drawTickMarks(t,yValues):
    for i in range(1,31):
        drawLine(t,20*i-300,-250,20*i-300,-240)
    for i in range(1,15):
        drawLine(t,-300,-250+40*i,-290,-250+40*i)
def displayText(t,yValues):
    
    t.pencolor("blue")
    t.up()
    t.goto(-310,(4*max(yValues))-250)
    t.write(max(yValues),align="center")
    t.goto(-310,(4*min(yValues))-250)
    t.write(min(yValues),align="center")
    x = 0
    for i in range(0,32,2):
        t.goto(x-300,-270)
        t.write(str(i),align="center")
        x += 40
    t.goto(320,-270)
    t.write("地震",font=("Arial",8,"normal"))
    y = -255
    for i in range(0,15):
        t.goto(-313,y)
        t.write(str(i*10),align="center")
        y += 40
    t.goto(-340,0)
    t.write("震源深度/km",font=("Arial",8,"normal"))
    t.goto(-100,-300)
    t.write("地震震源深度分析表",font=("Arial",16,"normal"))
def getxy(alist,xlist,ylist):
    for i in range(30):
        x=alist[i]
        xlist.append(int(float(x[2])))
        ylist.append(int(float(x[3])))
def drawaddress(xlist,ylist):   
    plt.plot()
    plt.title(" 地震信号分析表 ")
    plt.xlim(xmax=300,xmin=-300)
    plt.ylim(ymax=300,ymin=-300)
    plt.xlabel("x")
    plt.ylabel("y")
    plt.plot(xlist,ylist,'r.')
    plt.show()
def main():
    print("地震信息收集系统")
    zlist=[]
    alist=[]
    ilist=[]
    datalinks=[]
    xlist=[]
    ylist=[]
    olist=[]
    plist=[]
    url="http://www.ceic.ac.cn/"
    html=readhtml(url)
    analyze(html,alist,datalinks)
    collecttime(alist,plist,olist)
    filedeal(alist)
    filetohtml(alist,olist)
    datacollect(alist,zlist,ilist)
    getxy(alist,xlist,ylist)
    #draw(ilist,zlist)
    #drawaddress(xlist,ylist)

if __name__=='__main__':
    main()
