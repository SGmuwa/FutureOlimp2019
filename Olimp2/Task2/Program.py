import math
countTur = int(input("countTur"))
countGuide = int(input("countGuide"))
countInBus = int(input("countInBus"));
if countInBus < 3:
    print(0);
else:
    if countGuide / 2 * (countInBus - 2) <= countTur:
        print(0);
    else:
        N = countTur / (countInBus - 2);
        left = countTur % (countInBus - 2);
        if(left > 0):
            N += 1;
            countGuide -= left;
        countGuide -= 2 * N;
        if(countGuide > 0):
            N += math.ceil(countGuide / float(countInBus));
        print(N);