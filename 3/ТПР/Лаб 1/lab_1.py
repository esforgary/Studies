class Alternative:
    def __init__(self):
        self.attributes = []

    def assignSize(self, size):
        self.attributes = [0] * size

    def getAttributes(self):
        return self.attributes

    def assignAlternativeValue(self, values):
        self.attributes = values

    def compareAlternatives(self, alternative):
        evaluationArray = [0] * len(self.attributes)
        result = 4
        count1 = 0
        countm1 = 0
        for i in range(len(self.attributes)):
            if self.attributes[i] > alternative.attributes[i]:
                evaluationArray[i] = 1
            elif self.attributes[i] == alternative.attributes[i]:
                evaluationArray[i] = 0
            elif self.attributes[i] < alternative.attributes[i]:
                evaluationArray[i] = -1

        for i in range(len(evaluationArray)):
            if evaluationArray[i] == 1:
                count1 += 1
            elif evaluationArray[i] == -1:
                countm1 += 1

        if count1 > 0 and countm1 == 0:
            result = 1
        elif count1 > 0 and countm1 > 0:
            result = 0
        elif count1 == 0 and countm1 > 0:
            result = -1
        return result

    def plusOne(self, alternativeOptions):
        newAttributes = [0] * len(self.attributes)
        for i in range(len(alternativeOptions) - 1, -1, -1):
            if i != len(alternativeOptions) - 1:
                newAttributes[i + 1] = 1

            if self.attributes[i] < alternativeOptions[i]:
                newAttributes[i] = self.attributes[i] + 1
                for j in range(i - 1, -1, -1):
                    newAttributes[j] = self.attributes[j]
                break
            else:
                newAttributes[i] = self.attributes[i]
        return newAttributes

    def printAlternatives(self):
        for i in range(len(self.attributes)):
            if i == 0:
                print("( ", end="")
            print(f"K{i+1}{self.attributes[i]} ", end="")
            if i == len(self.attributes) - 1:
                print(") ", end="")


class AlternativeArray:
    def __init__(self):
        self.alternatives = []

    def assignSize(self, alternativeOptions):
        size = 1
        for i in range(len(alternativeOptions)):
            size *= alternativeOptions[i]
        self.alternatives = [Alternative() for i in range(size)]

    def fillArray(self, alternativeOptions):
        firstValues = [1] * len(alternativeOptions)
        self.alternatives[0].assignAlternativeValue(firstValues)
        for i in range(1, len(self.alternatives)):
            currentAlternative = self.alternatives[i - 1]
            self.alternatives[i].assignAlternativeValue(currentAlternative.plusOne(alternativeOptions))

    def findBest(self):
        print("Найкращій:")
        return self.alternatives[0]

    def findWorst(self):
        print("Найгіпший:")
        return self.alternatives[-1]

    def automaticComparison(self, alternative):
        better = []
        worse = []
        incomparable = []
        for alt in self.alternatives:
            if alternative.compareAlternatives(alt) == 1:
                better.append(alt)
            elif alternative.compareAlternatives(alt) == -1:
                worse.append(alt)
            else:
                incomparable.append(alt)
        print("\n\nКращі: ")
        iter1 = 0
        for item in better:
            iter1 +=1
        print(iter1)
        iter1 = 0
        print("\n\nГірщі: ")
        for item in worse:
            iter1 +=1
        print(iter1)
        print("\n\nНепорівнянні: ")
        iter1 = 0
        for item in incomparable:
            iter1 +=1
        print(iter1)
    def printArray(self):
        for i, alt in enumerate(self.alternatives):
            alt.printAlternatives()
            if (i + 1) % 5 == 0:
                print()
        print("\nАвтоматичне визначення кількості гіпотетично можливих альтернатив: " + str(len(self.alternatives)))

maxV = [2, 4, 3, 1]
altval = [1, 4, 2, 1]
alternative = Alternative()
alternativeArray = AlternativeArray()

alternative.assignAlternativeValue(altval)
alternativeArray.assignSize(maxV)
alternativeArray.fillArray(maxV)
alternativeArray.printArray()
print()
alternativeArray.findBest().printAlternatives()
print()
alternativeArray.findWorst().printAlternatives()
alternativeArray.automaticComparison(alternative)        