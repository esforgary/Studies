// завдання 1
batteries = () => {
    let countOfBatteris
    let percentOfReject

    countOfBatteris = prompt("Введіть кількіст батарей",)
    percentOfReject = prompt("Введіть відсоток браку",)

    if((countOfBatteris == null && percentOfReject == null)){
        alert("Невірно введені дані")
    } else {
        countOfBatteris = parseFloat(countOfBatteris)
        percentOfReject = parseFloat(percentOfReject)

        let countOfRejrctedBatteries =  Math.floor(countOfBatteris * percentOfReject / 100)
        let numbers = [countOfBatteris, percentOfReject, countOfRejrctedBatteries, countOfBatteris - countOfRejrctedBatteries]
        
        alert(`Кількість батарей: ${numbers[0]}
        \nПроцент браку: ${numbers[1]}%
        \nКількість бракованих батарей: ${numbers[2]}
        \nКількість робочих батарей: ${numbers[3]}`)
    }
}

// завдання 2
symbols = () => {
    let line = prompt("Введіть текст")

    let middleValue = line => {
        if(line.length === 1){
            return line
        } else {
            return (line.length % 2 !== 0) ? 
            line.at(Math.floor(line.length / 2)) : 
            line.substring(Math.floor(line.length / 2) - 1, Math.floor(line.length / 2) + 1)
        }
    }

    let decision = symbol => {
        if(symbol.includes(' ')){
        return "Невірно введені дані"
        } else if(symbol.length === 2 && symbol.at(0) === symbol.at(1)){
            return "Однакові символи"
        } else {
            return symbol
        }        
    }

    alert(decision(middleValue(line)))
}