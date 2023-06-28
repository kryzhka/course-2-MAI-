import numpy as np
import matplotlib.pyplot as plt
from matplotlib.animation import FuncAnimation
import sympy as sp

def Rot(X,Y,Alpha):
    RotX = X*np.cos(Alpha) - Y*np.sin(Alpha)
    RotY = X*np.sin(Alpha) + Y*np.cos(Alpha)
    return RotX, RotY


    

t = np.linspace(0, 360, 360)
phi = np.pi*t/180#угол в радианах
k= np.sin(phi)/3
s=np.sin(np.pi*t*4)/3



WeightA=4
HeightA=2
xTA = np.array([-WeightA/2, -WeightA/2, WeightA/2, WeightA/2,-WeightA/2])
yTA= np.array([-HeightA/2, HeightA/2, HeightA/2, -HeightA/2,-HeightA/2])
xA=0
yA=HeightA/2+1

WeightB=0.4
HeightB=0.3
xTB = np.array([-WeightB/2, -WeightB/2, WeightB/2, WeightB/2,-WeightB/2])
yTB= np.array([-HeightB/2, HeightB/2, HeightB/2, -HeightB/2,-HeightB/2])
#xB=-WeightA*phi#*(np.sin(phi)+np.cos(phi))
yB=HeightA+1+HeightB/2
MaxXB=WeightA*0.33
MinXB=WeightA*-0.33
lastX=MaxXB


def FxB(phi,s):
    #xB=-WeightA*phi
    global lastX
    
    print("lastX=",lastX)
    print(-WeightA*s)
    if(phi<=0):
        if(lastX>=MaxXB):
            lastX=MaxXB
            
            return lastX
        if(lastX<=MinXB):
            lastX=-WeightA*s
            return lastX
    else:
        if(lastX>=MaxXB):
            lastX=-WeightA*s
            return lastX
        if(lastX<=MinXB):
            
            lastX= MinXB
            return lastX
    if(phi<=0):
        lastX=-WeightA*phi*2+MinXB
    else:
        lastX=-WeightA*phi*2+MaxXB
    return lastX



fig = plt.figure(figsize=[25,25])
ax = fig.add_subplot(1,1,1)
ax.axis('equal')
ax.set(xlim=[-5,6],ylim=[0,10])


ax.plot([-7,-7,10],[10,0.125,0.125],color=[0,0.5,0],linewidth=2)#ск


A = ax.plot(Rot(xA+xTA,yA+yTA,k[0]),color=[0,0,0])[0]
B = ax.plot(Rot(FxB(k[0],s[0])+xTB,yB+yTB,k[0]),color=[0,0,0])[0]

def draw(i):
    
    A.set_data(Rot(xA+xTA,yA+yTA,k[i]))
    B.set_data(Rot(FxB(k[i],s[i])+xTB,yB+yTB,k[i]))
    
    return [A,B]

animation=FuncAnimation(fig,draw,interval = t[1]-t[0],frames=len(t))
plt.show()

