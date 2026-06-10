const API = "http://localhost:5173/api";

let ownerEditando = null;
let petEditando = null;

async function mostrar(id) {

    document
        .querySelectorAll("section")
        .forEach(s => s.classList.add("hidden"));

    document
        .getElementById(id)
        .classList.remove("hidden");

    // carregar dados ao mostrar a seção
    if (id === 'owners') await carregarOwners();
    if (id === 'pets') await carregarPets();
    if (id === 'appointments') await carregarAppointments();
}

async function carregarAppointments() {

    const response = await fetch(`${API}/Appointment`);

    const appointments = await response.json();

    const tabela = document.getElementById('appointmentTable');

    tabela.innerHTML = '';

    appointments.forEach(a => {
        tabela.innerHTML += `
            <tr>
                <td>${new Date(a.date).toLocaleString()}</td>
                <td>${a.petId}</td>
                <td>
                    <button onclick="excluirAppointment('${a.id}')">Excluir</button>
                </td>
                <td>
                    <button onclick="editarAppointment('${a.id}')">Editar</button>
                </td>
            </tr>
        `;
    });
}

document.getElementById('appointmentForm').addEventListener('submit', async e => {
    e.preventDefault();

    const body = {
        date: document.getElementById('appointmentDate').value,
        petId: document.getElementById('appointmentPetId').value
    };

    try {
        console.log('Creating appointment', body);

        let response;

        if (appointmentEditando) {
            const updateBody = { Date: body.date, PetId: body.petId };
            response = await fetch(`${API}/Appointment/${appointmentEditando}`, {
                method: 'PATCH',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(updateBody)
            });
        }
        else {
            response = await fetch(`${API}/Appointment`, {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(body)
            });
        }

        if (response.ok) {
            if (appointmentEditando) {
                appointmentEditando = null;
                document.querySelector('#appointmentForm button').innerText = 'Agendar';
                document.getElementById('appointmentForm').reset();
                await carregarAppointments();
            }
            else {
                alert('Agendamento criado');
                document.getElementById('appointmentForm').reset();
                await carregarAppointments();
            }
        }
        else {
            const erro = await response.text();
            alert(erro);
        }
    }
    catch (ex) {
        console.error('Erro ao criar agendamento', ex);
        alert('Erro ao conectar com a API: ' + ex.message);
    }
});

let appointmentEditando = null;

async function editarAppointment(id) {
    const response = await fetch(`${API}/Appointment/${id}`);
    if (!response.ok) { alert('Agendamento não encontrado'); return; }
    const ap = await response.json();
    document.getElementById('appointmentDate').value = ap.date ? ap.date.split('T')[0] : '';
    document.getElementById('appointmentPetId').value = ap.petId;
    appointmentEditando = id;
    document.querySelector('#appointmentForm button').innerText = 'Atualizar';
}

async function excluirAppointment(id) {
    if (!confirm('Deseja excluir esse agendamento?')) return;
    const response = await fetch(`${API}/Appointment/${id}`, { method: 'DELETE' });
    if (response.ok) await carregarAppointments();
}


async function carregarPets() {

    const response = await fetch(`${API}/Pet`);

    const pets = await response.json();

    const tabela = document.getElementById("petTable");

    tabela.innerHTML = "";

    pets.forEach(pet => {

        tabela.innerHTML += `
            <tr>
                <td>${pet.name}</td>
                <td>${pet.species}</td>
                <td>${pet.race}</td>
                <td>${pet.rg}</td>
                <td>${pet.ownerId}</td>
                <td>
                    <button onclick="excluirPet('${pet.id}')">Excluir</button>
                </td>
                <td>
                    <button onclick="editarPet('${pet.id}')">Editar</button>
                </td>
            </tr>
        `;
    });
}

document
    .getElementById("petForm")
    .addEventListener("submit", async e => {

        e.preventDefault();

        const body = {
            name: document.getElementById("petName").value,
            species: document.getElementById("species").value,
            race: document.getElementById("race").value,
            rg: document.getElementById("rg").value,
            birthDate: document.getElementById("petBirthDate").value,
            ownerId: document.getElementById("petOwnerId").value
        };

        try {
            console.log('Submitting pet form', { petEditando, body });

            let response;

            if (petEditando) {
                const updateBody = {
                    Name: body.name,
                    Species: body.species,
                    Race: body.race
                };

                console.log('PATCH pet body', updateBody);

                response = await fetch(`${API}/Pet/${petEditando}`, {
                    method: 'PATCH',
                    headers: { 'Content-Type': 'application/json' },
                    body: JSON.stringify(updateBody)
                });
            }
            else {
                response = await fetch(`${API}/Pet`, {
                    method: "POST",
                    headers: { "Content-Type": "application/json" },
                    body: JSON.stringify(body)
                });
            }

            if (response.ok) {
                if (petEditando) {
                    const editedId = petEditando;
                    petEditando = null;
                    document.querySelector('#petForm button').innerText = 'Cadastrar';
                    document.getElementById('petForm').reset();
                    await carregarPets();
                    try {
                        const check = await fetch(`${API}/Pet/${editedId}`);
                        if (check.ok) console.log('Pet atualizado no servidor:', await check.json());
                    }
                    catch (ex) { console.error('Erro ao verificar pet atualizado', ex); }
                }
                else {
                    alert('Pet cadastrado');
                    document.getElementById('petForm').reset();
                    await carregarPets();
                }
            }
            else {
                const erro = await response.text();
                alert(erro);
            }
        }
        catch (ex) {
            console.error('Erro ao criar pet', ex);
            alert('Erro ao conectar com a API: ' + ex.message);
        }
    });

async function editarPet(id) {

    const response = await fetch(`${API}/Pet/${id}`);

    if (!response.ok) {
        alert('Pet não encontrado');
        return;
    }

    const pet = await response.json();

    document.getElementById('petName').value = pet.name;
    document.getElementById('species').value = pet.species;
    document.getElementById('race').value = pet.race;
    // Não preencher RG, BirthDate ou OwnerId para edição (seguir restrição similar se necessário)

    // marcar edição
    petEditando = id;

    document.querySelector('#petForm button').innerText = 'Atualizar';
}

async function excluirPet(id) {

    if (!confirm('Deseja excluir esse pet?')) return;

    const response = await fetch(`${API}/Pet/${id}`, { method: 'DELETE' });

    if (response.ok) await carregarPets();
}


async function carregarOwners() {

    const response = await fetch(`${API}/Owner`);

    const owners = await response.json();

    const tabela = document.getElementById("ownerTable");

    tabela.innerHTML = "";

    owners.forEach(owner => {

        tabela.innerHTML += `
            <tr>
                <td>${owner.name}</td>
                <td>${owner.email}</td>
                <td>${owner.cpf}</td>
                <td>${owner.phoneNumber}</td>
                <td>
                    <button onclick="excluirOwner('${owner.id}')">
                        Excluir
                    </button>
                </td>
                <td>
                    <button onclick="editarOwner('${owner.id}')">
                        Editar
                    </button>
                </td>
            </tr>
        `;
    });
}

document
    .getElementById("ownerForm")
    .addEventListener("submit", async e => {

        e.preventDefault();

        const body = {
            name: document.getElementById("name").value,
            email: document.getElementById("email").value,
            cpf: document.getElementById("cpf").value,
            phoneNumber: document.getElementById("phoneNumber").value,
            birthDate: document.getElementById("birthDate").value
        };
        let response;

        try {
            // debug: payload e id em edição
            console.log('Submitting owner form', { ownerEditando, body });

            if (ownerEditando) {
            // enviar apenas os campos permitidos pelo UpdateOwnerDTO
            const updateBody = {
                Name: body.name,
                Email: body.email,
                PhoneNumber: body.phoneNumber
            };

            console.log('PATCH body', updateBody);
                response = await fetch(`${API}/Owner/${ownerEditando}`, {
                    method: "PATCH",
                    headers: { "Content-Type": "application/json" },
                    body: JSON.stringify(updateBody)
                });
            }
        else {
            response = await fetch(`${API}/Owner`, {
                method: "POST",
                headers: { "Content-Type": "application/json" },
                body: JSON.stringify(body)
            });
        }
            if (response.ok) {

                if (ownerEditando) {
                    alert("Proprietário atualizado");
                    const editedId = ownerEditando;
                    ownerEditando = null;
                    document.querySelector("#ownerForm button").innerText = "Cadastrar";

                    document.getElementById("ownerForm").reset();

                    // garantir que a lista seja recarregada antes de prosseguir
                    await carregarOwners();

                    // checar recurso no servidor para confirmar atualização
                    try {
                        const check = await fetch(`${API}/Owner/${editedId}`);
                        if (check.ok) {
                            const ownerUpdated = await check.json();
                            console.log('Owner no servidor após update:', ownerUpdated);
                        }
                        else {
                            console.warn('Não foi possível obter owner atualizado, status:', check.status);
                        }
                    }
                    catch (ex) {
                        console.error('Erro ao verificar owner atualizado:', ex);
                    }
                }
                else {
                    alert("Proprietário cadastrado");
                    document.getElementById("ownerForm").reset();
                    await carregarOwners();
                }
            }
            else {
                const erro = await response.text();
                console.error('Update failed', response.status, erro);
                alert(`Erro ${response.status}: ${erro}`);
            }
        }
        catch (ex) {
            console.error('Erro ao enviar requisição', ex);
            alert('Erro ao conectar com a API: ' + ex.message);
        }
    });


async function editarOwner(id) {

    const response =
        await fetch(`${API}/Owner/${id}`);

    const owner =
        await response.json();

    document.getElementById("name").value =
        owner.name;

    document.getElementById("email").value =
        owner.email;

    document.getElementById("phoneNumber").value =
        owner.phoneNumber;

    // Não preencher CPF e birthDate no formulário de edição — só nome, email e telefone

    ownerEditando = id;

    document
        .querySelector("#ownerForm button")
        .innerText = "Atualizar";
}

async function excluirOwner(id) {

    if (!confirm("Deseja excluir?"))
        return;

    const response = await fetch(`${API}/Owner/${id}`, {
        method: "DELETE"
    });

    if (response.ok) {
        await carregarOwners();
        await carregarPets();
        await carregarAppointments();
    }
}

async function buscarPet() {

    const id = document.getElementById("petId").value;

    const response = await fetch(`${API}/Pet/${id}`);

    const resultado =
        document.getElementById("petResult");

    if (response.ok) {

        const pet = await response.json();

        resultado.textContent =
            JSON.stringify(pet, null, 2);
    }
    else {
        resultado.textContent = "Pet não encontrado";
    }
}

async function buscarAppointment() {

    const id =
        document.getElementById("appointmentId").value;

    const response =
        await fetch(`${API}/Appointment/${id}`);

    const resultado =
        document.getElementById("appointmentResult");

    if (response.ok) {

        const appointment =
            await response.json();

        resultado.textContent =
            JSON.stringify(appointment, null, 2);
    }
    else {
        resultado.textContent =
            "Agendamento não encontrado";
    }
}

// carregar listas iniciais
(async () => {
    await carregarOwners();
    await carregarPets();
    await carregarAppointments();
})();
