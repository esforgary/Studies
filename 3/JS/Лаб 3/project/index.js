let str

str = prompt("Введіть якісь данні: ")

const check_uppercase = str => {
    if(/^[a-zA-Zа-яёА-ЯЁ]+$/.test(str[0])){
        let result = 'Перший символ рядка є маленьким'
        if (str[0] === str[0].toUpperCase()) {
            result = 'Перший символ рядка є великим'        
        }
        return result
    } else {
        return 'Перший символ рядка не є літерою'
    }
}

const count_of_words = str => { 
    let counter = 1    
    str = str.replace(/[\@\|\#\$\%\^\&\*\"\'\№\;\:\?\!\-\(\)\.\^\+\s]+/gim, ' ')
    str.replace(/(\s+)/g, function (a) {       
       counter++
    });

    let result = `Кількість слів у рядку = ${counter}`
    return result
}

const check_time = str => {
    let split = str.split(':')
    split.map(string => parseInt(string))
    
    let result = 'значення НЕ є показником часу'
    if(split.length === 3 && split[0] <= 23 && split[1] <= 59 && split[2] <= 59) {
        result = 'значення є показником часу'
    }
    return result
}

if(check_time(str) === 'значення є показником часу'){
    alert(check_time(str))
} else {
    alert(`${count_of_words(str)}\n` + `${check_uppercase(str)}\n`+ `${check_time(str)}`)
}