const roles = document.getElementById('roles')
const scenary = document.getElementById('scenary')
const btn = document.getElementById('btn')
const res = document.getElementById('res')

btn.addEventListener('click', () => {
    res.innerHTML = ''
    const rolesArray = roles.value.split(' ')
    const scenaryArray = scenary.value.split('\n')
    const finallScenary = {}

    scenaryArray.forEach((element, index) => {
        const replic = element.split(':')
        finallScenary.hasOwnProperty(replic[0])
            ? finallScenary[replic[0]].push((index + 1) + ')' + replic[1])
            : finallScenary[replic[0]] = [(index + 1) + ')' + replic[1]]
    })

    rolesArray.forEach(element => {
        res.innerHTML += element + '\n'
        finallScenary[element].forEach(replic => {
            res.innerHTML += replic + '\n'
        })
    })
})