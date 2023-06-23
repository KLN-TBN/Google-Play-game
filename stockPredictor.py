import json
from typing import Any, Dict, List
import pandas as pd
import numpy as np

import datetime as dt
import yfinance as yf
from pandas_datareader import data as pdr
import matplotlib.pyplot as plt
from sklearn.preprocessing import MinMaxScaler
from tensorflow.python.keras.models import Sequential
from tensorflow.python.keras.layers import Dense,Dropout, LSTM

company = "GLD" #can be any stock on yahoo finance

start = dt.datetime(2012,1,1)
end = dt.datetime.(2020,1,1)

yf.pdr_override()

data = pdr.get_data_yahoo(company, start, end)

scaler = MinMaxScaler(feature_range=(0,1))
scaled_data = scaler.fit_transform(data['Close'].values.reshape(-1,1))

prediction_days = 150

xTrain = []
yTrain = []

for x in range (prediction_days, len(scaled_data)):
    xTrain.append(scaled_data[x - prediction_days:x, 0])
    yTrain.append(scaled_data[x,0])
    
xTrain, yTrain = np.array(xTrain) , np.array(yTrain)
xTrain = np.reshape(xTrain, (xTrain.shape[0], xTrain.shape[1], 1))

model = Sequential()

model.add(LSTM(units = 50, return_sequences=True, input_shape = (xTrain.shape[1],1)))
model.add(Dropout(0.2))
model.add(LSTM(units = 50, return_sequences=True))
model.add(Dropout(0.2))
model.add(LSTM(units = 50, return_sequences=True))
model.add(Dropout(0.2))
model.add(LSTM(units = 50))
model.add(Dropout(0.2))
model.add(Dense(units = 1 ))

model.compile(optimizer = "adam" , loss = "mean_squared_error")
model.fit(xTrain, yTrain, epochs = 24, batch_size = 36)

testStart = dt.datetime(2020,1,1)
testEnd = dt.datetime.now()

testData = pdr.get_data_yahoo(company, testStart, testEnd)

actualPrices = testData['Close'].values

totalDataset = pd.concat((data['Close'], testData['Close']), axis = 0)

modelInputs = totalDataset[len(totalDataset) - len(testData) - prediction_days:].values
modelInputs = modelInputs.reshape(-1,1)
modelInputs = scaler.transform(modelInputs)

xTest = []

for x in range(prediction_days, len(modelInputs)):
    xTest.append(modelInputs[x-prediction_days:x, 0])

xTest = np.array(xTest)
xTest = np.reshape(xTest, (xTest.shape[0], xTest.shape[1],1))

predictedPrices = model.predict(xTest)
predictedPrices = scaler.inverse_transform(predictedPrices)

plt.plot(actualPrices, color = "black", label="actual price")
plt.plot(predictedPrices, color = "red", label="predicted price")

plt.xlabel("time")
plt.ylabel("stock price")

plt.show()
