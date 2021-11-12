
            <main>
            <section>
                <h2>Meus Eventos</h2>

                <div>
                    <table style={{ borderCollapse : 'separate', borderSpacing : 30 }}>

                        <thead>
                            <tr>
                                <th>IdConsulta</th>
                                <th>Situação</th>
                                <th>Médico</th>
                                <th>Paciente</th>
                                <th>data</th>
                                <th>Descrição</th>
                            </tr>
                        </thead>

                        <tbody>

                            {
                                ListarMinhasConsultas.map( (consulta) => {
                                    return(
                                        <tr key={consulta.idConsulta}>
                                            <td>{consulta.IdSituacao}</td>
                                            <td>{consulta.IdMedico}</td>
                                            <td>{consulta.idPaciente}</td>
                                            <td>{ Intl.DateTimeFormat("pt-BR", {
                                                year: 'numeric', month: 'numeric', day: 'numeric',
                                                hour: 'numeric', minute: 'numeric', hour12: true
                                            }).format(new Date(consulta.dataConsulta)) }</td>
                                            <td>{consulta.descricao}</td>
                                        </tr>
                                    )
                                } )                                
                            }
                            
                        </tbody>

                    </table>
                </div>
            </section>
        </main>