import numpy as np
import matplotlib.pyplot as plt
from matplotlib.animation import FuncAnimation
import sympy as sp

def Rot(X,Y,Alpha):
    RotX = X*np.cos(Alpha) - Y*np.sin(Alpha)
    RotY = X*np.sin(Alpha) + Y*np.cos(Alpha)
    return RotX, RotY
def sh(X,alpha):#dosn't work)
    if():
        X=-X
    return X

    

t = np.linspace(0, 15, 1001)
phi = np.sin(np.pi*t)/3#+np.pi/2#добавить ограничение
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
lastX=1

def FxB(phi):
    #xB=-WeightA*phi
    global lastX
    
    if(lastX>=MaxXB):
        print("!!!!!!!!!!!!!!!!!!!")# work
        if(phi<0):
            print("111")
            lastX=0*phi+MaxXB
            return lastX
        else:
            print("222")
            
            lastX=-WeightA*phi
            print(lastX)
            return lastX
    if(lastX<=MinXB):
        print("@@@@@@@@@@@@@@@@@@@@@@@")#not work
        if(phi>0):
            print("111????????")
            lastX= 0*phi+MinXB
            return lastX
        else:
            print("222")
            lastX=-WeightA*phi#поменял щнак
            return lastX
    if(phi<0):
        lastX=-WeightA*phi*2+MinXB
    else:
        lastX=-WeightA*phi*2+MaxXB
    return lastX
#//////
# i=0
# def FxB(phi,s):
#     #xB=-WeightA*phi
#     global lastX
#     global i
#     print("lastX=",lastX)
#     print(-WeightA*s)
#     if(phi<0):
#         if(lastX>=MaxXB):
#             lastX=MaxXB
#             i=0
#             return lastX
#         if(lastX<=MinXB):
#             lastX=-WeightA*s#поменял щнак
#             return lastX
        
#         # if(i==0):
#         #     lastX=-WeightA*s+2*MinXB
#         #     i+=1
#         #     print("!!!!!!!")
#         #     return lastX
        
#         #lastX=-WeightA*phi
#         #return lastX
#     else:
#         if(lastX>=MaxXB):
#             lastX=-WeightA*s
#             return lastX
#         if(lastX<=MinXB):
#             i=0
#             lastX= MinXB
#             return lastX
        
#         # if(i==0):
#         #     lastX=-WeightA*s+2*MaxXB
#         #     i+=1
#         #     print("@@@@@@@@@")
#         #     return lastX
        
#         #lastX=-WeightA*phi
#         #return lastX
#     lastX=-WeightA*phi
#     return lastX
# xB=MaxXB
#i=0
# def FxB(phi,s):
#     #xB=-WeightA*phi
#     global lastX
    
#     if(phi<0):
#         if(lastX>=MaxXB):
#             lastX=MaxXB
#             return lastX
#     else:
#         if(lastX<=MinXB):
#             lastX=MinXB
#             return lastX
#     lastX=-s*WeightA
#     return lastX
# xB=MaxXB
#xB=FxB(phi,xB)

def koef(alpha,flag):
    if((alpha>0)&(flag==0)):
        flag = 1
        return-phi
    if((alpha>0)&(flag==1)):
        return-phi


fig = plt.figure(figsize=[29,29])
ax = fig.add_subplot(1,1,1)
ax.axis('equal')
ax.set(xlim=[-5,6],ylim=[0,10])


ax.plot([-7,-7,10],[10,0.125,0.125],color=[0,0.5,0],linewidth=2)#ск


A = ax.plot(Rot(xA+xTA,yA+yTA,phi[0]),color=[0,0,1])[0]
B = ax.plot(Rot(FxB(phi[0])+xTB,yB+yTB,phi[0]),color=[0,1,0])[0]
def draw(i):
    A.set_data(Rot(xA+xTA,yA+yTA,phi[i]))
    B.set_data(Rot(FxB(phi[i])+xTB,yB+yTB,phi[i]))
    
    return [A,B]

animation=FuncAnimation(fig,draw,frames=len(t),interval=10)
plt.show()

