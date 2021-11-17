// Protobuf:
static int Calculate(int value){
	bool isPositive = (value & 1) == 0;
	if(isPositive){
		return (value >> 1) & 0x7FFFFFFF;
	}else{
		UInt32 ret = (UInt32)(value ^ 0xFFFFFFFF);
		ret >>= 1;
		ret |= 0x80000000;
		return (int)ret;
	}
}

// GetPFromC:
static float Calculate(float C){
	List<float> result = new List<float>();
	int count = (int)Math.Ceiling(1.0f / C);
	for(int i = 0; i < count; ++i){
		float mixedResult = 0;
		foreach(float v in result){
			mixedResult += v;
		}
		float curRate = (1.0f - mixedResult) * Math.Min(C * (i + 1), 1.0f);
		result.Add(curRate);
	}
	float ret = 0;
	for(int i = 0; i < count; ++i){
		ret += result[i] * (i + 1);
	}
	return 1.0f / ret;
}

// GetCFromP:
static float Dichotomy(float ret){
	float rate = 0.5f;
	float delta = 0.25f;
	while(true){
		float result = Calculate(rate);
		if(Math.Abs((int)Math.Round(result * 100) - (ret * 100)) < 0.001f){
			return rate;
		}
		if(result > ret){
			rate -= delta;
			delta *= 0.5f;
		}else if(result < ret){
			rate += delta;
			delta *= 0.5f;
		}
	}
}

// Teleport:
static void Calculate(int idx){
	if(!isSucceed){
		if(!spots[idx].isUsed){
			spots[idx].isUsed = true;
			if(idx >= spots.Count - 1){
				isSucceed = true;
				return;
			}
		}
		if(spots[idx].dist <= 0){
			return;
		}
		for(int i = spots[idx].dist; i >= 1; --i){
			if(isSucceed){
				return true;
			}
			if(idx + 1 >= spots.Count){
				isSucceed = true;
				return;
			}else{
				Calculate(idx + i);
			}
		}else{
			
		}
	}
}

// CheckValidUTF8Stream:
static bool Calculate(List<Byte> inputStream){
	int offset = 0;
	while(offset < inputStream.Count){
		Byte v = inputStream[offset];
		if(v >= 0x00 && v <= 0x7F){
			offset++;
		}else if(v >= 0xC0 && v <= 0xDF){
			offset++;
			if(!CheckNextByte(inputStream, offset)){
				return false;
			}
			offset++;
		}else if(v >= 0xE0 && v <= 0xEF){
			offset++;
			if(!CheckNextByte(inputStream, offset)){
				return false;
			}
			offset++;
			if(!CheckNextByte(inputStream, offset)){
				return false;
			}
			offset++;
		}else if(v >= 0xF0 && v <= 0xF7){
			offset++;
			if(!CheckNextByte(inputStream, offset)){
				return false;
			}
			offset++;
			if(!CheckNextByte(inputStream, offset)){
				return false;
			}
			offset++;
			if(!CheckNextByte(inputStream, offset)){
				return false;
			}
			offset++;
		}else{
			return false;
		}
	}
	return true;
}

static bool CheckNextByte(List<Byte> inputStream, int offset){
	if(offset >= inputStream.Count){
		return false;
	}
	Byte v = inputStream[offset];
	return(v >= 0x80 && v <= 0xBF);
}

// GetUnicodeCharCount:
static int Calculate(List<Byte> inputStream){
	int charCount = 0;
	int offset = 0;
	while(offset < inputStream.Count){
		Byte v = inputStream[offset];
		if(v >= 0x00 && v <= 0x7F){
			offset++;
			charCount++;
		}else if(v >= 0xC0 && v <= 0xDF){
			offset++;
			offset++;
			charCount++;
		}else if(v >= 0xE0 && v <= 0xEF){
			offset++;
			offset += 2;
			charCount++;
		}else if(v >= 0xF0 && v <= 0xF7){
			offset++;
			offset += 3;
			charCount++;
		}else{
			return -1;
		}
	}
	return charCount;
}

// PowerOf2
static int Calculate(int value){
	for(int i = 0; i < 32; ++i){
		if(value == 2 << i){
			return 1;
		}
	}
	return 0;
}
